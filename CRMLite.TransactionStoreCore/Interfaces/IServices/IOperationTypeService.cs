using CRMLite.TransactionStoreDomain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IServices
{
    public interface IOperationTypeService
    {
        Task<IEnumerable<OperationType>> GetAllOperationTypesAsync();
    }
}
