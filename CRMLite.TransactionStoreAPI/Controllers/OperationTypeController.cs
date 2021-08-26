using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CRMLite.TransactionStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "PermissionForAdminAndUserRoles")]
    public class OperationTypeController : Controller
    {
        private IOperationTypeService _operationTypeService;

        public OperationTypeController(IOperationTypeService operationTypeService)
        {
            _operationTypeService = operationTypeService;
        }

        [HttpGet]
        public async Task<IEnumerable<OperationType>> GetAllOperationTypesAsync()
        {
            return await _operationTypeService.GetAllOperationTypesAsync();
        }
    }
}
