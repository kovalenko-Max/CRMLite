using CRMLite.TransactionStoreAPI.RabbitMQ.Consumers;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RebbitMQMockController : ControllerBase
    {
        private IBusControl _busControl;

        public RebbitMQMockController(IBusControl busControl)
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
