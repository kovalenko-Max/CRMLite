using CRMLite.CRMCore.Entities;
using CRMLite.CRMServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRMLite.Core.Pagination;
using Microsoft.AspNetCore.Authorization;

namespace CRMLite.CRMAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(Policy = "PermissionForAdminAndUserRoles")]
    public class LeadController : ControllerBase
    {
        private ILeadService _leadService;

        public LeadController(ILeadService leadService)
        {
            _leadService = leadService;
        }

        [HttpGet("count")]
        public async Task<int> GetCountLeadsAsync()
        {
            return await _leadService.GetCountLeadsAsync();
        }

        [HttpGet("pagination")]
        public async Task<PaginationModel<Lead>> PaginateLeadsAsync(int currentPage=1)
        {
            return await _leadService.PaginateLeadsAsync(currentPage);
        }

        [HttpGet]
        public async Task<IEnumerable<Lead>> GetAllLeadsAsync()
        {
            return await _leadService.GetAllLeadsAsync();
        }

        [HttpGet("{id}")]
        public async Task<Lead> GetLeadByIdAsync(Guid id)
        {
            if (id != Guid.Empty)
            {
                return await _leadService.GetLeadByIdAsync(id);
            }

            throw new ArgumentException("Guid ID is empty");
        }

        [HttpPut]
        public async Task UpdateLeadAsync(Lead lead)
        {
            if (!(lead is null))
            {
                await _leadService.UpdateLeadAsync(lead);
            }
            else
            {
                throw new ArgumentNullException("Lead is null");
            }
        }

        [HttpDelete("{id}")]
        public async Task DeleteLeadAsync(Guid id)
        {
            if (id != Guid.Empty)
            {
                await _leadService.DeleteLeadByIDAsync(id);
            }
            else
            {
                throw new ArgumentException("LeadID is empty");
            }
        }
    }
}
