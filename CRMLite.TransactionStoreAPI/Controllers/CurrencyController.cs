using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : Controller
    {
        private ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet]
        public async Task<List<string>> GetAllCurrencyAsync()
        {
            return await _currencyService.GetAllCurrencyAsync();
        }
    }
}
