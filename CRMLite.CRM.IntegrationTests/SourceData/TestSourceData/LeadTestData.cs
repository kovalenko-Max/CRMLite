using CRMLite.Core.Contracts.Authorization.Roles;
using CRMLite.CRMCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMLite.CRM.IntegrationTests.SourceData.TestSourceData
{
    public static class LeadTestData
    {
        private static Lead _lead;

        static LeadTestData()
        {
            _lead = new Lead()
            {
                Id = Guid.NewGuid(),
                FirstName = "Ola",
                LastName = "Teranovich",
                Email = "oleksandrakondratenko@gmail.com",
                PassportNumber = "AE123456",
                Password = "Aa12345!",
                Role = null,
                StatusType = StatusType.Regular,
                TIN = "123456791"

            };
        }

        public static IEnumerable<object[]> GetTestDataForGetAll()
        {
            var leads = new List<Lead>();
            for (int i = 0; i < 5; i++)
            {
                leads.Add(new Lead()
                {
                    Id = Guid.NewGuid(),
                    FirstName = $"User{i}",
                    LastName = $"Teranovich{i}",
                    Email = $"email{i}@gmail.com",
                    PassportNumber = $"AE12345{i}",
                    Password = "Aa12345!",
                    Role = null,
                    StatusType = StatusType.Regular,
                    TIN = $"12345679{i}"
                });
            }

            yield return new object[]
            {
                leads
            };
        }

        public static IEnumerable<object[]> GetTestDataForGetOneLead()
        {
            yield return new object[]
            {
                _lead
            };
        }
    }
}
