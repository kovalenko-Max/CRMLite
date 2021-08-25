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
    public class StockRatesController : Controller
    {
        private readonly IStockRateRepository _stockRateRepository;

        public StockRatesController(IStockRateRepository stockRateRepository)
        {
            _stockRateRepository = stockRateRepository;
        }

        [HttpGet("code")]
        public async Task<ExchangeRate> GetLastStockRateAsync(string code)
        {
            if (code != string.Empty)
            {
                var response = await _stockRateRepository.GetLastStockRateAsync(code);

                return response;
            }
            else
            {
                throw new ArgumentException($"Code does not be empty");
            }
        }

        [HttpGet("codes")]
        public async Task<IEnumerable<ExchangeRate>> GetLastStockRatesAsync(string[] codes)
        {
            if (codes != null)
            {
                var response = await _stockRateRepository.GetLastStockRatesAsync(codes);

                return response;
            }

            throw new ArgumentNullException("Array codes is null");
        }
    }
}