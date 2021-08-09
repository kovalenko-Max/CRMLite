using CRMLite.CRMCore.Entities;
using CRMLite.CRMServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace CRMLite.CRMAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost]
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
    }
}
