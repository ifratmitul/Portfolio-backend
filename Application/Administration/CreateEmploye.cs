using Microsoft.AspNetCore.Identity;

namespace Application.Administration
{
    public class CreateEmploye
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Employee Employee { get; set; }
        }

        public class CreateEmployeeHandler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly RoleManager<IdentityRole> _roleManager;
            private readonly UserManager<AppAdmin> _userManager;
            public CreateEmployeeHandler(RoleManager<IdentityRole> roleManager, UserManager<AppAdmin> userManager)
            {
                _roleManager = roleManager;
                _userManager = userManager;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                // var role = _roleManager.FindByIdAsync(request.Employee.RoleId.ToString());
                // if (role == null) return Result<Unit>.Failure("Failed to find role");

                var user = new AppAdmin 
                {   Name = request.Employee.Name, 
                    UserName = request.Employee.Email, 
                    Email = request.Employee.Email 
                };

                var result = await _userManager.CreateAsync(user, request.Employee.Password);
                await _userManager.AddToRoleAsync(user, Roles.Basic.ToString());

                if (result.Succeeded)
                {
                    return Result<Unit>.Success(Unit.Value);
                }

                return Result<Unit>.AdminstrationFailure(result.Errors.Select(e => e.ToString()).ToArray());
            }
        }


    }
}
