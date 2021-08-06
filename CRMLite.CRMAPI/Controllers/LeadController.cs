using CRMLite.CRMAPI.JWT;
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
        private IConfirmMessageService _confirmMessageService;
        private ISessionService _jWTTokenHelper;
        private readonly IBusControl _busControl;

        public LeadController(ILeadService leadService, IConfirmMessageService confirmMessageService
            , IBusControl busControl, ISessionService jWTTokenHelper)
        {
            _leadService = leadService;
            _confirmMessageService = confirmMessageService;
            _busControl = busControl;
            _jWTTokenHelper = jWTTokenHelper;
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

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthentificationModel authenticationModel)
        {
            var lead = await _leadService.LoginAsync(authenticationModel);

            if(!BCrypt.Net.BCrypt.Verify(authenticationModel.Password, lead.Password))
            {
                return BadRequest("Uncorected Password");
            }

            var token = await _jWTTokenHelper.CreateAuthTokenAsync(lead);

            return Ok(token);
        }

        [HttpPut]
        public async Task UpdateLeadAsync(Lead lead)
        {
            await _leadService.UpdateLeadAsync(lead);
        }

        [HttpDelete("{id}")]
        public async Task DeleteLeadAsync(Guid id)
        {
            await _leadService.DeleteLeadByIdAsync(id);
        }

        [HttpGet("confirm")]
        public async Task<IActionResult> ConfirmEmail(string message)
        {
            var result = await _confirmMessageService.MailConfirmationResultAsync(message);
            return Ok(result);
        }
    }
}
