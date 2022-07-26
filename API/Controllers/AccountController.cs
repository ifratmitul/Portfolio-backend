using System.Security.Claims;
using API.DTOs;
using API.Services;

namespace API.Controllers
{
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

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<AdminDto>> Login(LoginDto logindto)
        {
            var user = await _userManager.FindByEmailAsync(logindto.Email);
            if (user == null) return Unauthorized();

            var result = await _signInManager.PasswordSignInAsync(user, logindto.Password, logindto.Remember , false);

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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateUser(EmployeeRegistrationModel employee) {
            
            var user = new AppAdmin {UserName = employee.Email, Email = employee.Email, Designation = employee.Designation  };
            var result = await _userManager.CreateAsync(user, employee.Password);

            if(result.Succeeded)
            {
                return Ok("Successfully Added Employee account");
            }

            return BadRequest(result.Errors);
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