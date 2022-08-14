using System.Net.Http;
using System.Security.Claims;
using API.DTOs;
using API.Services;
using Newtonsoft.Json;

namespace API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppAdmin> _userManager;
        private readonly SignInManager<AppAdmin> _signInManager;
        private readonly TokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        public AccountController(UserManager<AppAdmin> userManager, SignInManager<AppAdmin> signInManager,
            TokenService tokenService, IConfiguration config)
        {
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = config;
            _httpClient = new HttpClient()
            { BaseAddress = new System.Uri("https://graph.facebook.com") };


        }

        [HttpPost("login")]
        public async Task<ActionResult<AdminDto>> Login(LoginDto logindto)
        {
            var user = await _userManager.FindByEmailAsync(logindto.Email);
            if (user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, logindto.Password, false);

            if (result.Succeeded)
            {
                return CreateAdminObject(user);
            }

            return Unauthorized();

        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<AdminDto>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
            return CreateAdminObject(user);
        }

        [HttpPost("fblogin")]
        public async Task<ActionResult<AdminDto>> FacebookLogin(string accessToken)
        {
            var fbVerifyKeys = _configuration["Faceook:AppId"] + "|" + _configuration["Facebook:AppSecret"];
            var verifyToken = await _httpClient.GetAsync($"debug_token?input_token={accessToken}&access_token={fbVerifyKeys}");

            if (!verifyToken.IsSuccessStatusCode) return Unauthorized();

            var fbUrl = $"me?access_token={accessToken}&fields=name,email,picture.width(100).height(100)";
            var response = await _httpClient.GetAsync(fbUrl);
            if (!response.IsSuccessStatusCode) return Unauthorized();

            var content = await response.Content.ReadAsStringAsync();
            var fbInfo = JsonConvert.DeserializeObject<dynamic>(content);
            var username = (string)fbInfo.id;

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == username);
            if (user != null) return CreateAdminObject(user);

            user = new AppAdmin
            {
                Email = (string)fbInfo.email,
                Name = (string)fbInfo.name,
                AccessType = "User"
            };

            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                return CreateAdminObject(user);
            }

            return BadRequest("Problem creating account using facebook");
        }

        private AdminDto CreateAdminObject(AppAdmin admin)
        {
            return new AdminDto
            {
                Name = admin.Name,
                Email = admin.Email,
                Username = admin.UserName,
                Token = _tokenService.CreateToken(admin)
            };

        }
    }
}