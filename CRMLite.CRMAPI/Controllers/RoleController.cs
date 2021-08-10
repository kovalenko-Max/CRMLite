using CRMLite.Core.Contracts.Authorization.Roles;
using CRMLite.CRMServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.CRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "PermissionJustForAdminRole")]
    public class RoleController : ControllerBase
    {
        private IRoleService _roleService { get; set; }

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IEnumerable<RoleType>> GetAllRollesById(Guid id)
        {
            if (id != Guid.Empty)
            {
                return await _roleService.GetAllRolesByIdAsync(id);
            }

            throw new ArgumentException("Guid Role Id is Empty");
        }

        [HttpPost]
        public async Task AddRoleToLead(Guid leadId, int roleId)
        {
            if (leadId != Guid.Empty)
            {
                await _roleService.AddRoleToLeadAsync(leadId, roleId);
            }
            else
            {
                throw new ArgumentException("Guid LeadID is Empty");
            }
        }

        [HttpDelete]
        public async Task DeleteLeadRoleById(Guid id, int roleId)
        {
            if (id != Guid.Empty)
            {
                await _roleService.DeleteLeadRoleByIdAsync(id, roleId);
            }
            else
            {
                throw new ArgumentException("Guid LeadID is Empty");
            }
        }
    }
}
