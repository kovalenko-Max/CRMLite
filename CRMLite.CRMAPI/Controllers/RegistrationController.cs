using CRMLite.CRMCore.Entities;
using CRMLite.CRMServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
            var response = await _registrationService.RegistrationLeadAsync(
                lead, $"{Request.Scheme}://{Request.Host}");

            if (!response)
            {
                return BadRequest("Uncorrected data");
            }

            return Ok(response);
        }

        [HttpGet("confirm")]
        public async Task<IActionResult> ConfirmEmail(string message)
        {
            var response = await _registrationService.MailConfirmationResultAsync(message);

            if (!response)
            {
                return BadRequest("Uncorrected data");
            }

            return Ok(response);
        }
    }
}
