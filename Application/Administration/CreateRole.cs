using Microsoft.AspNetCore.Identity;

namespace Application.Administration
{
    public class CreateRole
    {
        public class Command : IRequest<Result<Unit>>
        {
            public EmployeeRole EmployeeRole { get; set; }
        }

        public class RoleCreateHandler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly RoleManager<IdentityRole> _roleManager;

            public RoleCreateHandler(RoleManager<IdentityRole> roleManager)
            {
                _roleManager = roleManager;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                IdentityRole newIdentityRole = new IdentityRole { Name = request.EmployeeRole.Name };
                var result = await _roleManager.CreateAsync(newIdentityRole);
                if (result.Succeeded)
                {
                    return Result<Unit>.Success(Unit.Value);
                }

                return Result<Unit>.Failure("Failed create Role");
            }
        }


    }
}
