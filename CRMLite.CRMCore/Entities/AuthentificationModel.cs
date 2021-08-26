using System.ComponentModel.DataAnnotations;

namespace CRMLite.CRMCore.Entities
{
    public class AuthentificationModel
    {
        [Required(ErrorMessage = "required field")]
        public string Email { get; set; }
        [Required(ErrorMessage = "required field")]
        public string Password { get; set; }
    }
}
