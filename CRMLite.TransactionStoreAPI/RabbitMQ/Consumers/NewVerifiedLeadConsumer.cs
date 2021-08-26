using CRMLite.Core.Messages;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using MassTransit;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreAPI.RabbitMQ.Consumers
{
    public class NewVerifiedLeadConsumer : IConsumer<NewVerifiedLeadMessage>
    {
        private readonly ILogger<ConsumerMock> _logger;
        private readonly IWalletService _walletService;

        public NewVerifiedLeadConsumer(ILogger<ConsumerMock> logger, IWalletService walletService)
        {
            _logger = logger;
            _walletService = walletService;
        }

        public async Task Consume(ConsumeContext<NewVerifiedLeadMessage> context)
        {
            _logger.LogInformation($"Create default wallet for lead by id {context.Message.LeadID.ToString()}");

            await _walletService.CreateDefaultWalletForLead(context.Message.LeadID);
        }
    }
}
