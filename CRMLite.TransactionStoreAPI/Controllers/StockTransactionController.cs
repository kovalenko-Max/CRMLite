using CRMLite.TransactionStoreAPI.Filters.Attributes;
using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockTransactionController : Controller
    {
        IStockTransactionService _stockTransactionService;

        public StockTransactionController(IStockTransactionService stockTransactionService)
        {
            _stockTransactionService = stockTransactionService;
        }

        [HttpGet("leadID")]
        public async Task<IEnumerable<StockTransaction>> GetAllStockTransactionsByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                var response = await _stockTransactionService.GetAllStockTransactionsByLeadIDAsync(leadID);

                return response;
            }

            throw new ArgumentException("Guid LeadID is empty");
        }

        [HttpGet("stockPortfolioID")]
        public async Task<IEnumerable<StockTransaction>> GetAllStockTransactionsByStockPortfolioIDAsync(Guid stockPortfolioID)
        {
            if (stockPortfolioID != Guid.Empty)
            {
                var response = await _stockTransactionService.GetAllStockTransactionsByStockPortfolioIDAsync(stockPortfolioID);

                return response;
            }

            throw new ArgumentException("Guid StockPortfolioID is empty");
        }

        [HttpPost]
        [TypeFilter(typeof(TwoFactorAuthorizeAttribute))]
        public async Task CreateStockTransactionAsync(StockTransaction stockTransaction)
        {
            if (stockTransaction != null)
            {
                await _stockTransactionService.CreateStockTransactionAsync(stockTransaction);
            }
            else
            {
                throw new ArgumentNullException("StockTransaction is null");
            }
        }
    }
}