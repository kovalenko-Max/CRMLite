using CRMLite.TransactionStoreDomain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IServices
{
    public interface ICurrencyService
    {
        Task<List<Currency>> GetAllCurrenciesAsync();
        Task<Currency> GetCurrencyByCodeAsync(string code);
        Task CreateCurrency(Currency currency);
    }
}
