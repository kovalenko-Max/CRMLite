using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreBLL.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository _repository;

        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            _repository = currencyRepository;
        }

        public async Task<List<Currency>> GetAllCurrencyAsync()
        {
            var responce = await _repository.GetAllCurrencyAsync();

            return responce;
        }
    }
}
