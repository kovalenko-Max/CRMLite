using CRMLite.CRMCore.Entities;
using System.Threading.Tasks;

namespace CRMLite.CRMServices.Interfaces
{
    public interface IAuthService
    {
        public Task CreateMailConfirmationAsync(Lead lead, string route);
        public Task<bool> MailConfirmationResultAsync(string message);
        public Task<ConfirmRegistration> RegistrationLeadAsync(Lead lead, string route);
        public Task<Lead> LoginAsync(AuthentificationModel authenticationModel);
    }
}
