using MassTransit;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CRMLite.CRMAPI.RabbitMQ.Consumer
{
    public class ConsumerMock : IConsumer<ClassMock>
    {
        private ILogger<ConsumerMock> _logger;

        public ConsumerMock(ILogger<ConsumerMock> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<ClassMock> context)
        {
        }
    }
}
