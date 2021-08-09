using CRMLite.CRMCore.Entities;
using System;
using System.Threading.Tasks;

namespace CRMLite.CRMServices.Interfaces
{
    public interface IAuthService
    {
        public Task CreateMailConfirmationAsync(Lead lead);
        public Task<bool> MailConfirmationResultAsync(string message);
        public Task<bool> RegistrationLeadAsync(Lead lead);
        public Task<Lead> LoginAsync(AuthentificationModel authenticationModel);
    }
}
