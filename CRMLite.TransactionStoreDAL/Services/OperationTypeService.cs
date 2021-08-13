using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreBLL.Services
{
    public class OperationTypeService : IOperationTypeService
    {
        private readonly IOperationTypeRepository _operationTypeRepository;

        public OperationTypeService(IOperationTypeRepository operationTypeRepository)
        {
            _operationTypeRepository = operationTypeRepository;
        }

        public async Task<IEnumerable<OperationType>> GetAllOperationTypesAsync()
        {
            var response = await _operationTypeRepository.GetAllOperationTypesAsync();

            return response;
        }
    }
}
