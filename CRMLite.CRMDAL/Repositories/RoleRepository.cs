using CRMLite.Core.Contracts.Authorization.Roles;
using CRMLite.CRMDAL.Interfaces;
using Insight.Database;
using System;
using System.Collections.Generic;
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

        public async Task AddRoleToLeadAsync(Guid leadId, int roleId)
        {
            if (leadId != Guid.Empty)
            {
                await _roleRepository.AddRoleToLeadAsync(leadId, roleId);
            }
            else
            {
                throw new ArgumentException("Guid LeadID is Empty");
            }
        }

        public async Task DeleteLeadRoleByIdAsync(Guid id, int roleId)
        {
            if (id != Guid.Empty)
            {
                await _roleRepository.DeleteLeadRoleByIdAsync(id, roleId);
            }
            else
            {
                throw new ArgumentException("Guid LeadID is Empty");
            }
        }

        public async Task<IEnumerable<RoleType>> GetAllRolesByIdAsync(Guid id)
        {
            if (id != Guid.Empty)
            {
                return await _roleRepository.GetAllRolesByIdAsync(id);
            }

            throw new ArgumentException("Guid Role Id is Empty");
        }
        public async Task<int> GetRoleID(int typeRole)
        {
            return await _roleRepository.GetRoleID(typeRole);
        }
    }
}
