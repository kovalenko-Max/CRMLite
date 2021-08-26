using CRMLite.TransactionStoreAPI.Filters.Attributes;
using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CRMLite.TransactionStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "PermissionForAdminAndUserRoles")]
    public class StockPortfolioController : Controller
    {
        private readonly IStockPortfolioService _stockPortfolioService;

        public StockPortfolioController(IStockPortfolioService stockPortfolioService)
        {
            _stockPortfolioService = stockPortfolioService;
        }

        [HttpGet("leadID")]
        public async Task<IEnumerable<StockPortfolio>> GetAllStockPortfoliosByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                var response = await _stockPortfolioService.GetAllStockPortfoliosByLeadIDAsync(leadID);

                return response;
            }

            throw new ArgumentException("Guid LeadID is empty");
        }

        [HttpPost]
        public async Task CreateStockPortfolioAsync(StockPortfolio stockPortfolio)
        {
            if (stockPortfolio != null)
            {
                await _stockPortfolioService.CreateStockPortfolioAsync(stockPortfolio);
            }
            else
            {
                throw new ArgumentNullException("StockPortfolio is null");
            }
        }
    }
}