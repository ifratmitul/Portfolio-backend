using API.DTOs;
using Application.Administration;
using Application.Interface;

namespace API.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
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
        public async Task<IActionResult> GetAllRoles()
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
            var users = _userManager.Users;
            return Ok(users);
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
    }
}