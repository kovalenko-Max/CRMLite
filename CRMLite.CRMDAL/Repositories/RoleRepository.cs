using CRMLite.CRMCore;
using CRMLite.CRMDAL.Interfaces;
using Insight.Database;
using System;
using System.Data;
using System.Threading.Tasks;

namespace CRMLite.CRMDAL.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IRoleRepository _roleRepository;
        public IDbConnection DBConnection { get; }

        public RoleRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _roleRepository = DBConnection.As<IRoleRepository>();
        }
        public async Task AddRolesToLeadAsync(Guid leadId, Guid roleId)
        {
            await _roleRepository.AddRolesToLeadAsync(leadId, roleId);
        }

        public async Task DeleteLeadRoleByIdAsync(Guid id)
        {
            await _roleRepository.DeleteLeadRoleByIdAsync(id);
        }

        public async Task<Roles> GetAllRollesByIdAsync(Guid id)
        {
            return await _roleRepository.GetAllRollesByIdAsync(id);
        }
    }
}
