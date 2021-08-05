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
    public class StockPortfolioController : Controller
    {
        private IStockPortfolioService _stockPortfolioService;

        public StockPortfolioController(IStockPortfolioService stockPortfolioService)
        {
            _stockPortfolioService = stockPortfolioService;
        }

        [HttpGet("{leadID}")]
        public async Task<IEnumerable<StockPortfolio>> GetAllStocksByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                var response = await _stockPortfolioService.GetStockPortfolioByLeadAsync(leadID);

                return response;
            }

            throw new ArgumentException("Guid LeadID is empty");
        }
    }
}