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
            if (!(confirmationMessage is null))
            {
                await _confirmMessageRepository.CreateConfirmMessageAsync(confirmationMessage);
            }
            else
            {
                throw new ArgumentNullException("ConfirmationMessageModel is null");
            }
        }

        public async Task<ConfirmationMessageModel> GetConfirmMessageByLeadIDAsync(Guid LeadID)
        {
            if (LeadID != Guid.Empty)
            {
                return await _confirmMessageRepository.GetConfirmMessageByLeadIDAsync(LeadID);
            }

            throw new ArgumentException("Guid LeadID is empty");
        }

        public async Task UpdateConfirmMessageAsync(ConfirmationMessageModel confirmationMessage)
        {
            if (!(confirmationMessage is null))
            {
                await _confirmMessageRepository.UpdateConfirmMessageAsync(confirmationMessage);
            }
            else
            {
                throw new ArgumentNullException("ConfirmationMessageModel is null");
            }
        }

        public async Task DeleteConfirmMessageAsync(Guid ID)
        {
            if (ID != Guid.Empty)
            {
                await _confirmMessageRepository.DeleteConfirmMessageAsync(ID);
            }
            else
            {
                throw new ArgumentException("Guid is empty");
            }
        }
    }
}
