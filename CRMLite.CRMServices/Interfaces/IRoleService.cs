using CRMLite.Core.Contracts.Roles;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.CRMServices.Interfaces
{
    public interface IRoleService
    {
        public Task AddRoleToLeadAsync(Guid leadId, RoleType roleType);
        public Task DeleteLeadRoleByIdAsync(Guid id, RoleType roleType);
        public Task<IEnumerable<RoleType>> GetAllRolesByIdAsync(Guid id);
        public Task<int> GetRoleID(int typeRole);
    }
}
