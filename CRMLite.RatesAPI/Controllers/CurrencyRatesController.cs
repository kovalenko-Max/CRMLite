using Microsoft.AspNetCore.Mvc;
using CRMLite.RatesDAL.Models;
using CRMLite.RatesDAL.IRepositories;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;

namespace CRMLite.RatesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyRatesController : Controller
    {
        private readonly ILogger<CurrencyRatesController> _logger;
        private readonly ICurrencyRateRepository _currencyRateRepository;

        public CurrencyRatesController(ICurrencyRateRepository exchangeRateRepository, ILogger<CurrencyRatesController> logger)
        {
            _currencyRateRepository = exchangeRateRepository;
            _logger = logger;
        }

        [HttpGet("code")]
        public async Task<ExchangeRate> GetLastCurrencyRate(string code)
        {
            if (code != string.Empty)
            {
                var response = await _currencyRateRepository.GetLastCurrencyRateAsync(code);
                return response;
            }
            else
            {
                throw new ArgumentException($"Code should not be empty");
            }
        }
    }
}
