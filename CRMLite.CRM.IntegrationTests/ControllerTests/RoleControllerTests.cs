// using CRMLite.Core.Contracts.Roles;
// using CRMLite.CRM.IntegrationTests.Factories;
// using CRMLite.CRM.IntegrationTests.SourceData.EnvironmentSourceData;
// using CRMLite.CRM.IntegrationTests.SourceData.TestSourceData;
// using CRMLite.CRMDAL.Repositories;
// using FluentAssertions;
// using Insight.Database;
// using Newtonsoft.Json;
// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using Xunit;
// using System.Linq;
//
// namespace CRMLite.CRM.IntegrationTests.ControllerTests
// {
//     public class RoleControllerTests : IntegrationTestAbstract
//     {
//         public RoleControllerTests(ApiWebApplicationFactory fixture) : base(fixture)
//         {
//         }
//
//         [Theory]
//         [MemberData(nameof(RoleTestData.GetTestData), MemberType = typeof(RoleTestData))]
//         public async Task GetAllRollesById_WhenValidTestPassed_ShouldReturnIEnumerableRoleType(List<RoleType> roles)
//         {
//             Initialize();
//             await InitializeEnvironmentData();
//             var leadRepository = new LeadRepository(_dbConnection);
//             var lead = (await leadRepository.GetAllLeadsAsync()).FirstOrDefault();
//
//             await AddRole(lead.Id, roles);
//
//             var getRoute = $"/api/Role?id={lead.Id}";
//             var getResponse = await SendRequestToGetAll(getRoute);
//             var actual = JsonConvert.DeserializeObject<IEnumerable<RoleType>>(await getResponse.Content.ReadAsStringAsync());
//
//             actual.Should().BeEquivalentTo(roles);
//         }
//
//         [Theory]
//         [MemberData(nameof(RoleTestData.GetTestData), MemberType = typeof(RoleTestData))]
//         public async Task AddRoleToLead_WhenValidTestPassed_ShouldReturnIEnumerableRoleType(List<RoleType> roles)
//         {
//             Initialize();
//             await InitializeEnvironmentData();
//             var leadRepository = new LeadRepository(_dbConnection);
//             var lead = (await leadRepository.GetAllLeadsAsync()).FirstOrDefault();
//
//             var postRoute = $"/api/Role?leadId={lead.Id}&roleType={roles.FirstOrDefault()}";
//             await SendRequestToCreate(null, postRoute);
//
//             var getRoute = $"/api/Role?id={lead.Id}";
//             var getResponse = await SendRequestToGetAll(getRoute);
//             var actual = JsonConvert.DeserializeObject<IEnumerable<RoleType>>(await getResponse.Content.ReadAsStringAsync());
//
//             actual.Should().BeEquivalentTo(roles.FirstOrDefault());
//         }
//
//         [Theory]
//         [MemberData(nameof(RoleTestData.GetTestData), MemberType = typeof(RoleTestData))]
//         public async Task DeleteRoleToLead_WhenValidTestPassed_ShouldReturnIEnumerableRoleType(List<RoleType> roles)
//         {
//             Initialize();
//             await InitializeEnvironmentData();
//             var leadRepository = new LeadRepository(_dbConnection);
//             var lead = (await leadRepository.GetAllLeadsAsync()).FirstOrDefault();
//
//             await AddRole(lead.Id, roles);
//
//             var deleteRoute = $"/api/Role?id={lead.Id}&roleType={roles.FirstOrDefault()}";
//             await SendRequestToDelete(deleteRoute);
//
//             var getRoute = $"/api/Role?id={lead.Id}";
//             var getResponse = await SendRequestToGetAll(getRoute);
//             var actual = JsonConvert.DeserializeObject<IEnumerable<RoleType>>(await getResponse.Content.ReadAsStringAsync());
//
//             actual.Should().BeEquivalentTo(roles[1]);
//         }
//
//         protected override async Task InitializeEnvironmentData()
//         {
//             var roleTypeLength = Enum.GetNames(typeof(RoleType)).Length;
//
//             for (int RoleType = 0; RoleType < roleTypeLength; ++RoleType)
//             {
//                 await _dbConnection.QueryAsync("[CRMLite].[CreateRole]", new { RoleType });
//             }
//
//             var leadRepository = new LeadRepository(_dbConnection);
//             await leadRepository.RegistrationLeadAsync(LeadEnviromentData.GetLead());
//         }
//
//         private async Task AddRole(Guid leadID, List<RoleType> roles)
//         {
//             foreach(RoleType role in roles)
//             {
//                 var roleRepository = new RoleRepository(_dbConnection);
//                 await roleRepository.AddRoleToLeadAsync(leadID, role);
//             }
//         }
//     }
// }
