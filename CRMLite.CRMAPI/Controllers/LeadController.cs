using CRMLite.CRMCore.Entities;
using CRMLite.CRMServices.Interfaces;
using MassTransit;
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
        private readonly IBusControl _busControl;

        public LeadController(ILeadService leadService, IBusControl busControl)
        {
            _leadService = leadService;
            _busControl = busControl;
        }

        [HttpGet]
        public async Task<IEnumerable<Lead>> GetAllLeadsAsync()
        {
            var response = await _leadService.GetAllLeadsAsync();

            return response;
        }

        [HttpGet("{id}")]
        public async Task<Lead> GetLeadByIdAsync(Guid id)
        {
            var response = await _leadService.GetLeadByIdAsync(id);

            return response;
        }

        [HttpPost("registration")]
        public async Task<IActionResult> RegistrationLeadAsync(Lead lead)
        {
            var response = await _leadService.RegistrationLeadAsync(lead, $"{Request.Scheme}://{Request.Host}");
            if (!response)
            {
                return BadRequest("Uncorrected data") ;
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task UpdateLeadAsync(Lead lead)
        {
            _leadService.UpdateLeadAsync(lead);
        }

        [HttpDelete]
        public async Task DeleteLeadAsync(Guid Id)
        {
            _leadService.DeleteLeadByIdAsync(Id);
        }
    }
}
