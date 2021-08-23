using CRMLite.CRMAPI.JWT;
using CRMLite.CRMCore.Entities;
using CRMLite.CRMServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace CRMLite.CRMAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private IAuthService _registrationService;
        private ISessionService _sessionService;

        public AuthController(IAuthService registrationService, ISessionService sessionService)
        {
            _registrationService = registrationService;
            _sessionService = sessionService;
        }

        [HttpPost("registration")]
        public async Task<IActionResult> RegistrationLeadAsync(Lead lead)
        {
            if (!(lead is null))
            {
                var response = await _registrationService.RegistrationLeadAsync(lead);

                if (!response)
                {
                    return BadRequest("Uncorrect data");
                }

                return Ok(response);
            }

            throw new ArgumentNullException("Lead is null");
        }

        [HttpGet("confirm")]
        public async Task<IActionResult> ConfirmEmail(string message)
        {
            var response = await _registrationService.MailConfirmationResultAsync(message);

            if (!response)
            {
                return BadRequest("Uncorrect data");
            }

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthentificationModel authenticationModel)
        {
            if (!(authenticationModel is null))
            {
                var lead = await _registrationService.LoginAsync(authenticationModel);

                if ((lead is null) || !BCrypt.Net.BCrypt.Verify(authenticationModel.Password, lead.Password))
                {
                    return BadRequest("Uncorected Email or Password");
                }

                LeadAccessInfo leadAccessInfo = new LeadAccessInfo();
                leadAccessInfo.LeadID = lead.Id;
                leadAccessInfo.Token = await _sessionService.CreateAuthTokenAsync(lead);

                return Ok(leadAccessInfo);
            }

            throw new ArgumentNullException("AuthentificationModel is null");
        }
    }
}
