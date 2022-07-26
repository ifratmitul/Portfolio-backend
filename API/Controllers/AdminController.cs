using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppAdmin> _userManager;

        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<AppAdmin> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpPost("createrole")]
        public async Task<IActionResult> CreateRole([FromForm] CreateRoleModel model)
        {

            IdentityRole newIdentityRole = new IdentityRole { Name = model.Name };
            var result = await _roleManager.CreateAsync(newIdentityRole);
            if (result.Succeeded)
            {
                return Ok("Succesfully create the role");
            }

            return BadRequest(result.Errors);
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
        public async Task<IActionResult> EditRole([FromForm] CreateRoleModel model, string Id)
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
        public async Task<IActionResult> CreateUser([FromForm] EmployeeRegistrationModel employee)
        {
            var role = _roleManager.FindByIdAsync(employee.RoleId.ToString());
            if(role == null) return NotFound("Role not found");

            var user = new AppAdmin { Name = employee.Name, UserName = employee.Email, Email = employee.Email, Designation = employee.Designation };
            var result = await _userManager.CreateAsync(user, employee.Password);
            await _userManager.AddToRoleAsync(user, role.Result.Name);

            if (result.Succeeded)
            {
                return Ok("Successfully Added Employee account");
            }

            return BadRequest(result.Errors);
        }

        [HttpPut("EditEmployee/{id}")]
        public async Task<IActionResult> EditUser(EmployeeRegistrationModel employee)
        {
            return NotFound();
        }
    }
}
