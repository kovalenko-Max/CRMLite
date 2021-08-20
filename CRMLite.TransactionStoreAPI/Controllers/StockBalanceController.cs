using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockBalanceController : Controller
    {
        private IStockBalanceService _stockBalanceService;

        public StockBalanceController(IStockBalanceService stockBalanceService)
        {
            _stockBalanceService = stockBalanceService;
        }

        [HttpGet("leadID")]
        public async Task<decimal> GetStockBalanceByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                var response = await _stockBalanceService.GetStockBalanceByLeadIDAsync(leadID);

                return response;
            }

            throw new ArgumentException("Guid LeadID is empty");
        }
    }
}
