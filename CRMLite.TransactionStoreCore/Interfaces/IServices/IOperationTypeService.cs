using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IServices
{
    public interface IOperationTypeService
    {
        Task<IEnumerable<string>> GetAllOperationTypesAsync();
    }
}
