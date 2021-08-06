using CRMLite.Core.Contracts.Authorization.Roles;
using System;
using System.Collections.Generic;

namespace CRMLite.CRMCore.Entities
{
    public class Lead
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasportNumber { get; set; }
        public string TIN { get; set; }
        public StatusType StatusType { get; set; }
        public List<RoleType> Role { get; set; }
    }
}
