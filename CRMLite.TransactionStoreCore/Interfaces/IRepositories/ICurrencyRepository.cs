using Insight.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IRepositories
{
    [Sql(Schema = "CRMLite")]
    public interface ICurrencyRepository : IRepository
    {
        Task<List<string>> GetAllCurrencyAsync();
    }
}
