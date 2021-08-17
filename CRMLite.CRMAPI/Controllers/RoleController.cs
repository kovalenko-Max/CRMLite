﻿using CRMLite.Core.Contracts.RolesAndStatuses;
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
        public async Task AddRoleToLead(Guid leadId, RoleType roleType)
        {
            if (leadId != Guid.Empty)
            {
                await _roleService.AddRoleToLeadAsync(leadId, roleType);
            }
            else
            {
                throw new ArgumentException("Guid LeadID is Empty");
            }
        }

        [HttpDelete]
        public async Task DeleteLeadRoleById(Guid id, RoleType roleType)
        {
            if (id != Guid.Empty)
            {
                await _roleService.DeleteLeadRoleByIdAsync(id, roleType);
            }
            else
            {
                throw new ArgumentException("Guid LeadID is Empty");
            }
        }
    }
}
