using CRMLite.RatesDAL.Models;
using Insight.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.RatesDAL.IRepositories
{
    [Sql(Schema = "CRMLite")]
    public interface IStockRateRepository
    {
        Task<ExchangeRate> GetLastStockRateAsync(string code);
        Task CreateStockRatesAsync(IEnumerable<ExchangeRate> exchangeRate);
    }
}