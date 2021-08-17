using CRMLite.Core.Contracts.RolesAndStatuses;
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
        public Task DeleteLeadRoleByIdAsync(Guid id, RoleType roleType);
        public Task AddRoleToLeadAsync(Guid leadId, RoleType roleType);
        public Task CreateRoleAsync(int RoleType);
        public Task<int> GetRoleID(int typeRole);
    }
}
