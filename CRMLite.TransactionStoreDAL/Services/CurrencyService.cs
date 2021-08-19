using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreBLL.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;

        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public async Task CreateCurrency(Currency currency)
        {
            await _currencyRepository.CreateCurrencyAsync(currency);
        }

        public async Task<List<Currency>> GetAllCurrenciesAsync()
        {
            var responce = await _currencyRepository.GetAllCurrenciesAsync();

            return responce;
        }

        public async Task<Currency> GetCurrencyByCodeAsync(string code)
        {
            var responce = await _currencyRepository.GetCurrencyByCodeAsync(code);

            return responce;
        }
    }
}
