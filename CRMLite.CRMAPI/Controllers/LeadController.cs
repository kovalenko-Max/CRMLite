using CRMLite.CRMCore.Entities;
using CRMLite.CRMServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.CRMAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeadController : ControllerBase
    {
        private ILeadService _leadService;

        public LeadController(ILeadService leadService)
        {
            _leadService = leadService;
        }

        [HttpGet]
        public async Task<IEnumerable<Lead>> GetAllLeads()
        {
            var response = await _leadService.GetAllLeadsAsync();

            return response;
        }

        [HttpGet("{Id}")]
        public async Task<Lead> GetLeadById(Guid id)
        {
            var response = await _leadService.GetLeadByIdAsync(id);

            return response;
        }

        [HttpPost("registration")]
        public async Task<Guid> RegistrationLead(Lead lead)
        {
            var response = await _leadService.RegistrationLeadAsync(lead);

            return response;
        }

        [HttpPut]
        public async Task UpdateLead(Lead lead)
        {
            _leadService.UpdateLeadAsync(lead);
        }

        [HttpDelete]
        public async Task DeleteLead(Guid Id)
        {
            _leadService.DeleteLeadByIdAsync(Id);
        }
    }
}
