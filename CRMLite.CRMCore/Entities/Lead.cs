using CRMLite.Core.Contracts.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CRMLite.Core.Contracts.Statuses;

namespace CRMLite.CRMCore.Entities
{
    public class Lead
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "required field")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "required field")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "required field")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "required field")]
        public string Password { get; set; }
        public string PassportNumber { get; set; }

        [StringLength(12, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 10)]
        public string TIN { get; set; }
        public StatusType StatusType { get; set; }
        public List<RoleType> Role { get; set; }
    }
}
