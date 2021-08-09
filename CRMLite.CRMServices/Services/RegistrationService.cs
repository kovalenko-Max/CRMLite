using CRMLite.CRMCore.Entities;
using CRMLite.CRMCore.Helper;
using CRMLite.CRMDAL.Interfaces;
using CRMLite.CRMServices.Interfaces;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using CRMLite.Core.Contracts.Authorization.Roles;
using System.Text.RegularExpressions;

namespace CRMLite.CRMServices.Services
{
    public class RegistrationService : IRegistrationService
    {

        private readonly IMailExchangeService _mailExchangeService;
        private readonly ILeadRepository _leadRepository;
        private IConfirmMessageRepository _confirmMessageRepository { get; set; }

        public RegistrationService(IDBContext dBContext, IMailExchangeService mailExchangeService)
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
            if (!(lead is null))
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

            throw new ArgumentNullException("Lead is null");
        }

        public async Task<bool> MailConfirmationResultAsync(string message)
        {
            if (!(message is null))
            {
                var decrypted = EncryptionHelper.Decrypt(message);
                var model = JsonSerializer.Deserialize<ConfirmationMessageModel>(decrypted);
                var confirmMessageDB = await _confirmMessageRepository.GetConfirmMessageByLeadIDAsync(model.LeadID);

                if (model.ConfirmMessage == confirmMessageDB.ConfirmMessage)
                {
                    var lead = await _leadRepository.GetLeadByIDAsync(model.LeadID);
                    lead.Role.Add(RoleType.User);
                    await _leadRepository.UpdateLeadAsync(lead);

                    return true;
                }

                return false; 
            }

            throw new ArgumentNullException("Message is null");
        }

        public async Task<bool> RegistrationLeadAsync(Lead lead)
        {
            if(!(lead is null))
            {
                if (IsPasswordValid(lead.Password))
                {
                    lead.Password = BCrypt.Net.BCrypt.HashPassword(lead.Password);
                    lead.Id = Guid.NewGuid();
                    await _leadRepository.RegistrationLeadAsync(lead);
                    await CreateMailConfirmationAsync(lead);

                    return true;
                }

                return false;
            }

            throw new ArgumentNullException("Lead is null");
        }

        private bool IsPasswordValid(string password)
        {
            var regEx = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])((?=.*?[0-9])|(?=.*?[#?!@$%^&*-]))", RegexOptions.Compiled);

            return regEx.IsMatch(password);
        }
    }
}
