using CRMLite.Core.Contracts.Authorization.Roles;
using System.Collections.Generic;

namespace CRMLite.Core.Contracts.Authorization.Policies
{
    public class AdminsPolicy : IPolicy
    {
        public string Title
        {
            get
            {
                return nameof(AdminsPolicy);
            }
        }

        public List<string> Roles { get; private set; }

        public AdminsPolicy()
        {
            Roles = new List<string>()
            {
                RoleType.Admin.ToString()
            };
        }
    }
}
