// namespace API.Services
// {
//     public class AdminService : IAdmin
//     {
//         private readonly RoleManager<IdentityRole> _roleManager;
//         private readonly UserManager<AppAdmin> _userManager;
//         private readonly DataContext _context;

//         public AdminService(RoleManager<IdentityRole> roleManager, UserManager<AppAdmin> userManager, DataContext context)
//         {
//             _roleManager = roleManager;
//             _userManager = userManager;
//             _context = context;
//         }

//         public async Task<IActionResult> CreateUser(EmployeeRegistrationModel employee)
//         {
//             var user = new AppAdmin { UserName = employee.Email, Email = employee.Email, Designation = employee.Designation };

//             var result = await _userManager.CreateAsync(user, employee.Password);
//             bool save = await _context.SaveChangesAsync() > 0;

//             return null;
//             //if (result.Succeeded && save)
//             //{
//             //    return Ok("Successfully Added Employee account");
//             //}

//             //return BadRequest(result.Errors);
//         }
//     }
// }
