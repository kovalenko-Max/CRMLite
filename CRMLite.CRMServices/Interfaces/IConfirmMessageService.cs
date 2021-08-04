using CRMLite.CRMCore.Entities;
using System;
using System.Threading.Tasks;

namespace CRMLite.CRMServices.Interfaces
{
    public interface IConfirmMessageService
    {
        public Task CreateConfirmMessageAsync(ConfirmationMessageModel confirmationMessage);
        public Task<ConfirmationMessageModel> GetConfirmMessageByLeadIDAsync(Guid ID);
        public Task UpdateConfirmMessageAsync(ConfirmationMessageModel confirmationMessage);
        public Task DeleteConfirmMessageAsync(Guid ID);
        public Task CreateMailConfirmationAsync(Lead lead);
        public Task<bool> MailConfirmationResultAsync(string message);
    }
}
