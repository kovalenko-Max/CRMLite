using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IRepositories
{
    public interface IOperationTypeRepository : IRepository
    {
        Task<IEnumerable<string>> GetAllOperationTypesAsync();
    }
}
