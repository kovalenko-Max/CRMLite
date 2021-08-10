using CRMLite.Core.Contracts.Authorization.Roles;
using Microsoft.Extensions.DependencyInjection;

namespace CRMLite.Core.Contracts.Authorization
{
    public static class AddAuthorizationByPolicies
    {
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
