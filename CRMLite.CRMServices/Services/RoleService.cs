using CRMLite.Core.Contracts.Authorization.Roles;
using CRMLite.CRMDAL.Interfaces;
using CRMLite.CRMServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.CRMServices.Services
{
    public class RoleService : IRoleService
    {
        IRoleRepository _roleRepository { get; set; }
        public RoleService(IDBContext dBContext)
        {
            _roleRepository = dBContext.RoleRepository;
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

        public async Task<IEnumerable<RoleType>> GetAllRolesByIDAsync(Guid id)
        {
            if (id != Guid.Empty)
            {
                return await _roleRepository.GetAllRollesByIdAsync(id);
            }

                throw new ArgumentException("Guid Role Id is Empty");
        }

        public async Task<int> GetRoleID(int typeRole)
        {
            return await _roleRepository.GetRoleID(typeRole);
        }
    }
}
