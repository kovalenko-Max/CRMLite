using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CRMLite.TransactionStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TFAController : ControllerBase
    {
        private ITFAService _tFAService;

        public TFAController(ITFAService tFAService)
        {
            _tFAService = tFAService;
        }

        [HttpGet("model")]
        public async Task<TFAModel> GetTFAModelByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                var tfaModel = await _tFAService.GetTFAModelAsync(leadID);

                return tfaModel;
            }

            throw new ArgumentException("Guid leadID is empty");
        }

        [HttpGet("TFAExist")]
        public async Task<bool> IsLeadTFAExistAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                var result = await _tFAService.IsLeadTFAExistAsync(leadID);

                return result;
            }

            throw new ArgumentException("Guid leadID is empty");
        }

        [HttpPost]
        public async Task<bool> ConnectTFAToLead(Guid leadID, string pin)
        {
            if (leadID != Guid.Empty && pin != null)
            {
                var result = await _tFAService.ConfirmConnectTFAToLeadAsync(leadID, pin);

                return result;
            }
            else if (leadID == Guid.Empty)
            {
                throw new ArgumentException("Guid leadID is empty");
            }

            throw new ArgumentNullException("String pin is null");
        }
    }
}
