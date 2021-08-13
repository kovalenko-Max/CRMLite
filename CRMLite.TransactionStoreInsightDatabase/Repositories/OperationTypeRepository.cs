using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using Insight.Database;
using System;
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

        public async Task<IEnumerable<OperationType>> GetAllOperationTypesAsync()
        {
            var response = await _operationTypeRepository.GetAllOperationTypesAsync();

            return response;
        }

        public async Task CreateOperationTypeAsync(OperationType operationType)
        {
            if (operationType != null)
            {
                await _operationTypeRepository.CreateOperationTypeAsync(operationType);
            }
            else if (operationType == null)
            {
                throw new ArgumentNullException("OperationType is null");
            }
        }
    }
}
