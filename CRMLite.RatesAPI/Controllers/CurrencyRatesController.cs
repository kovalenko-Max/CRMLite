using CRMLite.RatesDAL.IRepositories;
using CRMLite.RatesDAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.RatesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyRatesController : Controller
    {
        private readonly ICurrencyRateRepository _currencyRateRepository;

        public CurrencyRatesController(ICurrencyRateRepository exchangeRateRepository)
        {
            _currencyRateRepository = exchangeRateRepository;
        }

        [HttpGet("code")]
        public async Task<ExchangeRate> GetLastCurrencyRateAsync(string code)
        {
            if (code != string.Empty)
            {
                var response = await _currencyRateRepository.GetLastCurrencyRateAsync(code);

                return response;
            }

            throw new ArgumentException($"Code does not be empty");
        }

        [HttpPost("codes")]
        public async Task<IEnumerable<ExchangeRate>> GetLastCurrencyRatesAsync(string[] codes)
        {
            if (codes != null)
            {
                var response = await _currencyRateRepository.GetLastCurrencyRatesAsync(codes);

                return response;
            }

            throw new ArgumentNullException("Array codes is null");
        }
    }
}
