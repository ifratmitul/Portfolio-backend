using System.Security.Claims;
using API.DTOs;
using API.Services;

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
        public AccountController(UserManager<AppAdmin> userManager, SignInManager<AppAdmin> signInManager, TokenService tokenService)
        {
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userManager = userManager;

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