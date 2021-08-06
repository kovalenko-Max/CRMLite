using CRMLite.CRMCore.Entities;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace CRMLite.CRMAPI
{
    public class LeadSubmittedEventConsumer : IConsumer<Lead>
    {
        public async Task Consume(ConsumeContext<Lead> context)
        {
            Console.WriteLine("Order Submitted: {0}", context.Message.Id);
        }
    }
}
