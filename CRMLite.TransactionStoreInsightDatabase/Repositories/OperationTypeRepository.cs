using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using Insight.Database;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreInsightDatabase.Repositories
{
    public class OperationTypeRepository : IOperationTypeRepository
    {
        private readonly IOperationTypeRepository _operationTypeRepository;
        public IDbConnection DBConnection { get; }

        public OperationTypeRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _operationTypeRepository = DBConnection.As<IOperationTypeRepository>();
        }

        public async Task<IEnumerable<string>> GetAllOperationTypesAsync()
        {
            return await _operationTypeRepository.GetAllOperationTypesAsync();
        }
    }
}
