using System.Text;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Persistence;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentity<AppAdmin, IdentityRole>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<DataContext>()
            .AddSignInManager<SignInManager<AppAdmin>>();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

            });

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("AdminPolicy", (policy) =>
            //    {
            //        policy.RequireRole("SuperAdmin");
            //    });

            //    options.AddPolicy("AdminManagerPolicy", (policy) =>
            //    {
            //        policy.RequireRole("Admin");
            //    });

            //    options.AddPolicy("AdminManagerClerkPolicy", (policy) =>
            //    {
            //        policy.RequireRole("Editor", "Manager", "Moderator");
            //    });
            //});

            services.AddScoped<TokenService>();
            return services;
        }

    }
}