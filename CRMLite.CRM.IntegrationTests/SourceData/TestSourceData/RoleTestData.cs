using CRMLite.Core.Contracts.RolesAndStatuses;
using System.Collections.Generic;

namespace CRMLite.CRM.IntegrationTests.SourceData.TestSourceData
{
    public static class RoleTestData
    {
        private static List<RoleType> roles;

        static RoleTestData()
        {
            roles = new List<RoleType> { RoleType.User, RoleType.Admin };
        }

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[]
            {
                roles
            };
        }
    }
}
