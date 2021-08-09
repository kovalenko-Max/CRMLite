using Insight.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IRepositories
{
    public interface IOperationTypeRepository : IRepository
    {
        [Sql(Schema = "CRMLite")]
        Task<IEnumerable<string>> GetAllOperationTypesAsync();
    }
}
