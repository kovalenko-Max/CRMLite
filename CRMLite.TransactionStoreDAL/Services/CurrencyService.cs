using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreBLL.Services
{
    public class CurrencyService : ICurrencyService
    {
        private ICurrencyRepository _repository;

        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            _repository = currencyRepository;
        }

        public async Task<List<string>> GetAllCurrencyAsync()
        {
            var responce = await _repository.GetAllCurrencyAsync();

            return responce;
        }
    }
}
