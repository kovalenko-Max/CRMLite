using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BalanceController : Controller
    {
        private IBalanceService _balanceService;

        public BalanceController(IBalanceService balanceService)
        {
            _balanceService = balanceService;
        }

        [HttpGet("{leadID}")]
        public async Task<decimal> GetBalanceByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                var response = await _balanceService.GetBalanceByLeadIDAsync(leadID);

                return response;
            }

            throw new ArgumentException("Guid LeadID is empty");
        }
    }
}
