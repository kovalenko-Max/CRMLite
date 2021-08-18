using CRMLite.CRMCore.Entities;
using System;
using CRMLite.Core.Contracts.Statuses;

namespace CRMLite.CRM.IntegrationTests.SourceData.EnvironmentSourceData
{
    public static class LeadEnviromentData
    {
        public static Lead GetLead()
        {
            return new Lead
            {
                Id = Guid.NewGuid(),
                FirstName = "Ola",
                LastName = "Teranovich",
                Email = "oleksandrakondratenko@gmail.com",
                PassportNumber = "AE123456",
                Password = "Aa12345!",
                StatusType = StatusType.Regular,
                TIN = "123456791"
            };
        }
    }
}
