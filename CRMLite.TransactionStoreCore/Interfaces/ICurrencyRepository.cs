using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces
{
    public interface ICurrencyRepository : IRepository
    {
        Task<List<string>> GetAllCurrencyAsync();
    }
}
