using CRMLite.Core.Contracts.Authorization.Roles;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.CRMDAL.Interfaces
{
    [Sql(Schema = "CRMLite")]
    public interface IRoleRepository:IRepository
    {
        public Task<IEnumerable<RoleType>> GetAllRolesByIdAsync(Guid id);
        public Task DeleteLeadRoleByIdAsync(Guid id, int roleId);
        public Task AddRoleToLeadAsync(Guid leadId, int roleId);
        public Task<int> GetRoleID(int typeRole);
    }
}
