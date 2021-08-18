using CRMLite.CRMCore.Entities;
using Insight.Database;
using System;
using System.Threading.Tasks;

namespace CRMLite.CRMDAL.Interfaces
{
    [Sql(Schema = "CRMLite")]
    public interface IConfirmMessageRepository: IRepository
    {
        Task CreateConfirmMessageAsync(ConfirmationMessageModel confirmationMessage);
        Task<ConfirmationMessageModel> GetConfirmMessageByLeadIDAsync(Guid leadID);
        Task UpdateConfirmMessageAsync(ConfirmationMessageModel confirmationMessage);
        Task DeleteConfirmMessageByLeadIDAsync(Guid ID);
    }
}
