using CRMLite.CRM.IntegrationTests.Factories;
using CRMLite.CRM.IntegrationTests.SourceData.TestSourceData;
using CRMLite.CRMCore.Entities;
using CRMLite.CRMDAL.Repositories;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CRMLite.CRM.IntegrationTests.ControllerTests
{
    public class LeadControllerIntegrationTest : IntegrationTestAbstract
    {
        public LeadControllerIntegrationTest(ApiWebApplicationFactory fixture) : base(fixture)
        {

        }

        [Theory]
        [MemberData(nameof(LeadTestData.GetTestDataForGetAll), MemberType = typeof(LeadTestData))]
        public async Task GetAllLeads_WhenValidTestPassed_ShouldReturnIEnumerableLeads(List<Lead> leads)
        {
            Initialize();

            foreach (var lead in leads)
            {
                await CreateLead(lead);
            }

            var getRoute = $"/api/Lead";
            var getResponse = await SendRequestToGetAll(getRoute);
            var actual = JsonConvert.DeserializeObject<IEnumerable<Lead>>(await getResponse.Content.ReadAsStringAsync());

            actual.Should().BeEquivalentTo(leads);
        }

        [Theory]
        [MemberData(nameof(LeadTestData.GetTestDataForGetOneLead), MemberType = typeof(LeadTestData))]
        public async Task GetLeadByID_WhenValidTestPassed_ShouldReturnLead(Lead lead)
        {
            Initialize();

            await CreateLead(lead);
          
            var getRoute = $"/api/Lead/{lead.Id}";
            var getResponse = await SendRequestToGetByID(getRoute);
            var actual = JsonConvert.DeserializeObject<Lead>(await getResponse.Content.ReadAsStringAsync());

            actual.Should().BeEquivalentTo(lead);
        }

        [Theory]
        [MemberData(nameof(LeadTestData.GetTestDataForGetOneLead), MemberType = typeof(LeadTestData))]
        public async Task UpdateLead_WhenValidTestPassed_ShouldUpdateLead(Lead lead)
        {
            Initialize();

            await CreateLead(lead);
            lead.FirstName = "UpdateName";
            lead.LastName = "UpdateLastName";

            var putRoute = $"/api/Lead";
            var putResponse = await SendRequestToUpdate(lead,putRoute);
            
            var getRoute = $"/api/Lead/{lead.Id}";
            var getResponse = await SendRequestToGetByID(getRoute);

            var actual = JsonConvert.DeserializeObject<Lead>(await getResponse.Content.ReadAsStringAsync());
            actual.Should().BeEquivalentTo(lead);
        }

        [Theory]
        [MemberData(nameof(LeadTestData.GetTestDataForGetOneLead), MemberType = typeof(LeadTestData))]
        public async Task DeleteLead_WhenValidTestPassed_ShouldDelete(Lead lead)
        {
            Initialize();

            await CreateLead(lead);

            var deleteRoute = $"/api/Lead/{lead.Id}";
            var deleteResponse = await SendRequestToDelete(deleteRoute);

            var getRoute = $"/api/Lead/{lead.Id}";
            var getResponse = await SendRequestToGetByID(getRoute);

            getResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        protected override Task InitializeEnvironmentData()
        {
            throw new NotImplementedException();
        }

        private async Task CreateLead(Lead lead)
        {
            var repository = new LeadRepository(_dbConnection);
            await repository.RegistrationLeadAsync(lead);
        }
    }
}
