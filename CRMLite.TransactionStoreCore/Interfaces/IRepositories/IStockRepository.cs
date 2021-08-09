using CRMLite.TransactionStoreDomain.Entities;
using Insight.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IRepositories
{
    [Sql(Schema = "CRMLite")]
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> GetAllStocksAsync();
    }
}
