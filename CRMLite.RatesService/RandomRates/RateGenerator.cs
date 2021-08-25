using CRMLite.RatesDAL.IRepositories;
using CRMLite.RatesDAL.Models;
using System;
using System.Collections.Generic;

namespace CRMLite.RatesService.RandomRates
{
    public class RateGenerator : IRatesService
    {
        private readonly ICurrencyRateRepository _currencyRateRepository;
        private readonly IStockRateRepository _stockRateRepository;

        public RateGenerator(ICurrencyRateRepository currencyRateRepository, IStockRateRepository stockRateRepository)
        {
            _currencyRateRepository = currencyRateRepository;
            _stockRateRepository = stockRateRepository;
        }

        public void CreateCurrencyExchangeRates()
        {
            _currencyRateRepository.CreateCurrencyRatesAsync(GetRandomExchangeRate(GetCurrencyRandomModels()));
        }
        
        public void CreateStockExchangeService()
        {
             _stockRateRepository.CreateStockRatesAsync(GetRandomExchangeRate(GetStockRandomModels()));
        }

        private IEnumerable<ExchangeRate> GetRandomExchangeRate(IEnumerable<ExchangeRandomModel> exchangeRandomModels)
        {
            var ExchangeRates = new List<ExchangeRate>();
            var random = new Random();

            foreach (var randomModel in exchangeRandomModels)
            {
                ExchangeRates.Add(
                    new ExchangeRate(
                    Guid.NewGuid(),
                    DateTime.Now,
                    randomModel.Code,
                    random.NextDouble()
                    * (randomModel.MaxRandomvalue - randomModel.MinRandomValue)
                    + randomModel.MinRandomValue
                ));
            }

            return ExchangeRates;
        }

        private IEnumerable<ExchangeRandomModel> GetCurrencyRandomModels()
        {
            var models = new List<ExchangeRandomModel>();

            models.Add(new ExchangeRandomModel("USD", 1, 1));
            models.Add(new ExchangeRandomModel("UAH", 24, 30));
            models.Add(new ExchangeRandomModel("RUB", 50, 100));
            models.Add(new ExchangeRandomModel("EUR", 1, 2));

            return models;
        }

        private IEnumerable<ExchangeRandomModel> GetStockRandomModels()
        {
            var models = new List<ExchangeRandomModel>();

            models.Add(new ExchangeRandomModel("TSLA", 100, 120));
            models.Add(new ExchangeRandomModel("AAPL", 50, 100));
            models.Add(new ExchangeRandomModel("ALFA", 25, 50));
            models.Add(new ExchangeRandomModel("GLNG", 1, 4));
            models.Add(new ExchangeRandomModel("KER", 40, 50));
            models.Add(new ExchangeRandomModel("UKRP", 10, 12));
            models.Add(new ExchangeRandomModel("VOO", 15, 16));
            models.Add(new ExchangeRandomModel("YASK", 3, 5));

            return models;
        }
    }
}