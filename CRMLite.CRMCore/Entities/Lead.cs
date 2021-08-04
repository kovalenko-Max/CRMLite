using System;

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
        public Roles Role { get; set; }
    }
}
