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

        [HttpGet("{leadID}")]
        public async Task<IEnumerable<StockTransaction>> GetAllTransactionByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                var response = await _stockTransactionService.GetAllTransactionByLeadIDAsync(leadID);

                return response;
            }

            throw new ArgumentException("Guid leadID is empty");
        }

        [HttpGet("{stockID}")]
        public async Task<IEnumerable<StockTransaction>> GetAllStockTransactionByStockID(Guid stockID)
        {
            if (stockID != Guid.Empty)
            {
                var response = await _stockTransactionService.GetAllStockTransactionByStockID(stockID);

                return response;
            }

            throw new ArgumentException("Guid stockID is empty");
        }

        [HttpPost]
        public async Task CreateStockTransactionAsync(StockTransaction stockTransaction)
        {
            if (stockTransaction != null)
            {
                await _stockTransactionService.CreateStockTransactionAsync(stockTransaction);
            }
            else
            {
                throw new ArgumentNullException("stockTransaction is null");
            }
        }
    }
}