using CRMLite.CRMAPI.JWT;
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
        private ISessionService _jWTTokenHelper;

        public LeadController(ILeadService leadService, ISessionService jWTTokenHelper)
        {
            _leadService = leadService;
            _jWTTokenHelper = jWTTokenHelper;
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

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthentificationModel authenticationModel)
        {
            if (!(authenticationModel is null))
            {
                var lead = await _leadService.LoginAsync(authenticationModel);

                if (!BCrypt.Net.BCrypt.Verify(authenticationModel.Password, lead.Password))
                {
                    return BadRequest("Uncorect password");
                }

                var token = await _jWTTokenHelper.CreateAuthTokenAsync(lead);

                return Ok(token);
            }

            throw new ArgumentNullException("AuthentificationModel is null");
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
            if (!(id != Guid.Empty))
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
