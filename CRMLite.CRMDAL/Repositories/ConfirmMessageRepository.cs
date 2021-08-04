using CRMLite.CRMCore.Entities;
using CRMLite.CRMDAL.Interfaces;
using Insight.Database;
using System;
using System.Data;
using System.Threading.Tasks;

namespace CRMLite.CRMDAL.Repositories
{
    public class ConfirmMessageRepository : IConfirmMessageRepository
    {
        public IDbConnection DBConnection { get; }
        private readonly IConfirmMessageRepository _confirmMessageRepository;

        public ConfirmMessageRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _confirmMessageRepository = DBConnection.As<IConfirmMessageRepository>();
        }

        public async Task CreateConfirmMessageAsync(ConfirmationMessageModel confirmationMessage)
        {
            await _confirmMessageRepository.CreateConfirmMessageAsync(confirmationMessage);
        }

        public async Task<ConfirmationMessageModel> GetConfirmMessageByLeadIDAsync(Guid LeadID)
        {
           return await _confirmMessageRepository.GetConfirmMessageByLeadIDAsync(LeadID);
        }

        public async Task UpdateConfirmMessageAsync(ConfirmationMessageModel confirmationMessage)
        {
            await _confirmMessageRepository.UpdateConfirmMessageAsync(confirmationMessage);
        }

        public async Task DeleteConfirmMessageAsync(Guid ID)
        {
            await _confirmMessageRepository.DeleteConfirmMessageAsync(ID);
        }
    }
}
