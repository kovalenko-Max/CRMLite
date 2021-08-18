using CRMLite.Core.Contracts.Roles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CRMLite.Core.Contracts
{
    public static class StarupExtension
    {
        public static void AddAuthenticationLead(this IServiceCollection services, string secretKey)
        {
            var key = Encoding.ASCII.GetBytes(secretKey);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }

        public static void AddAuthorizationLeads(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("PermissionJustForAdminRole",
                    policy => policy.RequireRole(RoleType.Admin.ToString()));
                options.AddPolicy("PermissionForAdminAndUserRoles",
                    policy => policy.RequireRole(RoleType.User.ToString(), RoleType.Admin.ToString()));
            });
        }
    }
}
