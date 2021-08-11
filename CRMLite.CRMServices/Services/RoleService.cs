using CRMLite.Core.Contracts.RolesAndStatuses;
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
        public async Task AddRoleToLeadAsync(Guid leadId, RoleType roleType)
        {
            if (leadId != Guid.Empty)
            {
                await _roleRepository.AddRoleToLeadAsync(leadId, roleType);
            }
            else
            {
                throw new ArgumentException("Guid LeadID is Empty");
            }
        }

        public async Task DeleteLeadRoleByIdAsync(Guid id, RoleType roleType)
        {
            if (id != Guid.Empty)
            {
                await _roleRepository.DeleteLeadRoleByIdAsync(id, roleType);
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
