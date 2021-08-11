using CRMLite.Core.Contracts.Authorization.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
