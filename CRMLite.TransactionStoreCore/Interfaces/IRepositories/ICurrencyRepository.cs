using CRMLite.TransactionStoreDomain.Entities;
using Insight.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IRepositories
{
    [Sql(Schema = "CRMLite")]
    public interface ICurrencyRepository 
    {
        Task<List<Currency>> GetAllCurrenciesAsync();
        Task CreateCurrencyAsync(Currency currency);
        Task<Currency> GetCurrencyByCodeAsync(string code);
    }
}
