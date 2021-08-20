using CRMLite.TransactionStoreDomain.Entities;
using Insight.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IRepositories
{
    [Sql(Schema = "CRMLite")]
    public interface IOperationTypeRepository : IRepository
    {
        Task<IEnumerable<OperationType>> GetAllOperationTypesAsync();
        Task CreateOperationTypeAsync(OperationType operationType);
    }
}
