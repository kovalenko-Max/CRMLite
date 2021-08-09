using CRMLite.Core.Contracts.Authorization.Roles;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.CRMServices.Interfaces
{
    public interface IRoleService
    {
        public Task AddRoleToLeadAsync(Guid leadId, int roleId);
        public Task DeleteLeadRoleByIdAsync(Guid id,int roleId);
        public Task<IEnumerable<RoleType>> GetAllRolesByIDAsync(Guid id);
        public Task<int> GetRoleID(int typeRole);
    }
}
