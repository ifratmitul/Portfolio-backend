using API.DTOs;
using Application.Administration;

namespace API.Controllers
{
    // [Authorize(Roles = "SuperAdmin")]
    [AllowAnonymous]
    public class AdminController : BaseApiController
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppAdmin> _userManager;
        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<AppAdmin> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpPost("createrole")]
        public async Task<IActionResult> CreateRole([FromForm] EmployeeRole model)
        {
            return HandleResult(await Mediator.Send(new CreateRole.Command { EmployeeRole = model }));
        }

        [HttpGet("GetRoles")]
        public IActionResult GetAllRoles()
        {
            var roles = _roleManager.Roles;
            if (roles == null) return NotFound("No role exists");
            List<RoleDto> list = new();
            foreach (IdentityRole role in roles)
            {
                list.Add(new RoleDto { Id = role.Id, RoleName = role.Name });
            }
            return Ok(list);
        }

        [HttpPut("EditRole/{id}")]
        public async Task<IActionResult> EditRole([FromForm] EmployeeRole model, string Id)
        {
            var RoleId = Id;
            var role = await _roleManager.FindByIdAsync(model.RoleId);
            if (role == null) return NotFound();

            role.Name = model.Name;
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                return Ok("Succesfully changed Role Name");
            }

            return BadRequest(result.Errors);
        }

        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAction()
        {
            var currentUer = await _userManager.GetUserAsync(HttpContext.User);
            var users = await _userManager.Users.Where(u => u.Id != currentUer.Id).ToListAsync();
            var userList = new List<EmployeeDto>();
            foreach (var user in users)
            {
                var employeeVm = new EmployeeDto()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    Roles = await getUserRoles(user)

                };
                userList.Add(employeeVm);
            }
            return Ok(userList);
        }

        private async Task<List<string>> getUserRoles(AppAdmin user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }

        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> CreateUser([FromForm] Employee employee)
        {
            return HandleResult(await Mediator.Send(new CreateEmploye.Command { Employee = employee }));
        }

        [HttpPut("EditEmployee/{id}")]
        public async Task<IActionResult> EditUser(Employee employee)
        {
            return NotFound();
        }

        [HttpGet("GetUserInfo/{id}")]
        public async Task<ActionResult<EmployeeDto>> GetUserInfo([FromQuery] string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            var employeeDetails = new EmployeeDto
            {
                Name = user.Name,
                Email = user.Email,
                Roles = await getUserRoles(user),
            };

            return employeeDetails;
        }

        [HttpPost("ChangePermission/{id}")]
        public async Task<IActionResult> ChangePermission([FromForm]PermissionChange pc)
        {
            var user = await _userManager.FindByIdAsync(pc.UserId);
            if (user == null) return NotFound();

            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                return BadRequest("Can not remove existing role");
            }

            foreach (string item in pc.Roles)
            {
                result = await _userManager.AddToRoleAsync(user, item);
                if (!result.Succeeded) return BadRequest("Failed to add roles");
            }

            return Ok("Successfully changed roles");

        }

    }
}