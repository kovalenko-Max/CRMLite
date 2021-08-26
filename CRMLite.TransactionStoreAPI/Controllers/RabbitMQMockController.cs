using CRMLite.TransactionStoreAPI.RabbitMQ.Consumers;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CRMLite.TransactionStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "PermissionForAdminAndUserRoles")]
    public class RabbitMQMockController : ControllerBase
    {
        private IBusControl _busControl;

        public RabbitMQMockController(IBusControl busControl)
        {
            _busControl = busControl;
        }

        [HttpPost]
        public async Task PostMessage(ClassMock mock)
        {
            await _busControl.Publish(mock);
        }
    }
}
