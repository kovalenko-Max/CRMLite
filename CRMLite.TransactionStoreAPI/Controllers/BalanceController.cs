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
        private IStockBalanceService _stockBalanceService;

        public BalanceController(IBalanceService balanceService, IStockBalanceService stockBalanceService)
        {
            _balanceService = balanceService;
            _stockBalanceService = stockBalanceService;
        }

        [HttpGet("leadID")]
        public async Task<decimal> GetBalanceByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                var response = await _balanceService.GetBalanceByLeadIDAsync(leadID);

                return response;
            }

            throw new ArgumentException("Guid LeadID is empty");
        }

        [HttpGet("totalBalance/leadID")]
        public async Task<decimal> GetTotalBalanceByLeadIDAsync(Guid leadID)
        {
            decimal response = 0;

            if (leadID != Guid.Empty)
            {
                response += await _balanceService.GetBalanceByLeadIDAsync(leadID);
                response += await _stockBalanceService.GetStockBalanceByLeadIDAsync(leadID);

                return response;
            }

            throw new ArgumentException("Guid LeadID is empty");
        }
    }
}
