using CRMLite.CRMCore.Entities;
using CRMLite.CRMCore.Helper;
using CRMLite.CRMDAL.Interfaces;
using CRMLite.CRMServices.Interfaces;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using CRMLite.Core.Contracts.Roles;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Data.SqlClient;
using CRMLite.Core.Messages;
using MassTransit;
using Microsoft.Extensions.Configuration;

namespace CRMLite.CRMServices.Services
{
    public class AuthService : IAuthService
    {

        private readonly IMailExchangeService _mailExchangeService;
        private readonly ILeadRepository _leadRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IBusControl _busControl;
        private readonly IConfiguration _config;
        private IConfirmMessageRepository _confirmMessageRepository { get; }

        public AuthService(IDBContext dBContext, IMailExchangeService mailExchangeService, IBusControl busControl, IConfiguration config)
        {
            _confirmMessageRepository = dBContext.ConfirmMessageRepository;
            _mailExchangeService = mailExchangeService;
            _leadRepository = dBContext.LeadRepository;
            _roleRepository = dBContext.RoleRepository;
            _busControl = busControl;
            _config = config;
        }

        public async Task CreateMailConfirmationAsync(Lead lead, string route)
        {
            var confirmationMessage = new ConfirmationMessageModel
            {
                ConfirmMessage = StringGenerator.GenerateString(),
                LeadID = lead.Id,
                StatusType = lead.StatusType
            };

            await _confirmMessageRepository.CreateConfirmMessageAsync(confirmationMessage);
            var modelToSerialize = JsonSerializer.Serialize(confirmationMessage);
            var messageToSend = EncryptionHelper.Encrypt(modelToSerialize);

            var confirmationString = $"{route}/api/Auth/confirm?message={messageToSend}";

            _mailExchangeService.SendMessage(lead.Email, lead.FirstName, confirmationString);
         }

        public async Task<bool> MailConfirmationResultAsync(string message)
        {
            if (!(message is null))
            {
                var decrypted = EncryptionHelper.Decrypt(message);
                var model = JsonSerializer.Deserialize<ConfirmationMessageModel>(decrypted);
                var confirmMessageDB = await _confirmMessageRepository.GetConfirmMessageByLeadIDAsync(model.LeadID);
                NewVerifiedLeadMessage newVerifiedLeadMessage = new NewVerifiedLeadMessage()
                {
                    LeadID = model.LeadID
                };

                if (model.ConfirmMessage == confirmMessageDB.ConfirmMessage)
                {
                    await _roleRepository.AddRoleToLeadAsync(confirmMessageDB.LeadID, RoleType.User);

                    await _busControl.Publish(newVerifiedLeadMessage);

                    return true;
                }

                return false;
            }

            throw new ArgumentException("Message is empty");
        }

        public async Task<ConfirmRegistration> RegistrationLeadAsync(Lead lead, string route )
        {
            var response = new ConfirmRegistration();

            try
            {
                if (!(lead is null))
                {
                    if (IsPasswordValid(lead.Password))
                    {
                        lead.Password = BCrypt.Net.BCrypt.HashPassword(lead.Password);
                        lead.Id = Guid.NewGuid();
                        lead.StatusType = 0;
                        await _leadRepository.RegistrationLeadAsync(lead);
                        await CreateMailConfirmationAsync(lead, route);

                        response.IsConfirmed=true;
                        response.Message = "Check your email to confirm registration";
                        return response;
                    }
                    else
                    {
                        response.IsConfirmed = false;
                        response.Message = "Password is not valid";
                        return response;
                    }
                }
                else
                {
                    response.IsConfirmed = false;
                    response.Message = "Lead is null";
                    return response;
                }
            }
            catch (SqlException e)
            {
                response.IsConfirmed = false;

                if (e.Number == 2627)
                {
                    response.Message = "Email already exist";
                }
                else
                {
                    response.Message = "Service error";
                }

                return response;
            }
            catch (Exception e)
            {
                response.IsConfirmed = false;
                response.Message = "Argument exception";
                return response;
            }
        }

        public async Task<Lead> LoginAsync(AuthentificationModel authenticationModel)
        {
            if (!(authenticationModel is null))
            {
                var lead = await _leadRepository.GetLeadByEmailAsync(authenticationModel.Email);

                if (!(lead is null))
                {
                    lead.Role = new List<RoleType>(await _roleRepository.GetAllRolesByIdAsync(lead.Id));
                }
                else
                {
                    throw new ArgumentNullException("Lead is null");
                }

                return lead;
            }

            throw new ArgumentNullException("AuthentificationModel is null");
        }

        private bool IsPasswordValid(string password)
        {
            var regEx = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])((?=.*?[0-9])|(?=.*?[#?!@$%^&*-]))", RegexOptions.Compiled);

            return regEx.IsMatch(password);
        }

    }
}
