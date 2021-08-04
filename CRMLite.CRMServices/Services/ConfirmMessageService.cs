using CRMLite.CRMCore.Entities;
using CRMLite.CRMCore.Helper;
using CRMLite.CRMDAL.Interfaces;
using CRMLite.CRMServices.Interfaces;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace CRMLite.CRMServices.Services
{
    public class ConfirmMessageService : IConfirmMessageService
    {

        private readonly IMailExchangeService _mailExchangeService;
        private readonly ILeadRepository _leadRepository;
        private IConfirmMessageRepository _confirmMessageRepository { get; set; }

        public ConfirmMessageService(IDBContext dBContext, IMailExchangeService mailExchangeService)
        {
            _confirmMessageRepository = dBContext.ConfirmMessageRepository;
            _mailExchangeService = mailExchangeService;
            _leadRepository = dBContext.LeadRepository;
        }

        public async Task CreateConfirmMessageAsync(ConfirmationMessageModel confirmationMessage)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteConfirmMessageAsync(Guid ID)
        {
            throw new NotImplementedException();
        }

        public async Task<ConfirmationMessageModel> GetConfirmMessageByLeadIDAsync(Guid ID)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateConfirmMessageAsync(ConfirmationMessageModel confirmationMessage)
        {
            throw new NotImplementedException();
        }

        public async Task CreateMailConfirmationAsync(Lead lead)
        {
            var confirmationMessage = new ConfirmationMessageModel
            {
                ConfirmMessage = StringGenerator.GenerateString(),
                LeadID = lead.Id
            };

            await _confirmMessageRepository.CreateConfirmMessageAsync(confirmationMessage);
            var modelToSerialize = JsonSerializer.Serialize(confirmationMessage);
            var messageToSend = EncryptionHelper.Encrypt(modelToSerialize);

            var confirmationString = $"http://localhost:1234/Lead/confirm?message={messageToSend}";

            _mailExchangeService.SendMessage(lead.Email, lead.FirstName, confirmationString);
        }

        public async Task<bool> MailConfirmationResultAsync(string message)
        {
            var decrypted = EncryptionHelper.Decrypt(message);
            var model = JsonSerializer.Deserialize<ConfirmationMessageModel>(decrypted);
            var confirmMessageDB = await _confirmMessageRepository.GetConfirmMessageByLeadIDAsync(model.LeadID);

            if (model.ConfirmMessage == confirmMessageDB.ConfirmMessage)
            {
                var lead = await _leadRepository.GetLeadByIDAsync(model.LeadID);
                lead.Role = CRMCore.Roles.User;
                await _leadRepository.UpdateLeadAsync(lead);

                return true;
            }

            return false;
        }
    }
}
