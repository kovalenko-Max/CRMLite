using CRMLite.Core.Contracts.Authorization.Roles;
using System.Collections.Generic;

namespace CRMLite.Core.Contracts.Authorization.Policies
{
    public class BasePolicy : IPolicy
    {
        public string Title
        {
            get
            {
                return nameof(BasePolicy);
            }
        }

        public List<string> Roles { get; private set; }

        public BasePolicy()
        {
            Roles = new List<string>()
            {
                RoleType.User.ToString(),
                RoleType.Admin.ToString()
            };
        }
    }
}
