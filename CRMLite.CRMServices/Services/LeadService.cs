using CRMLite.CRMCore.Entities;
using CRMLite.CRMCore.Helper;
using CRMLite.CRMDAL.Interfaces;
using CRMLite.CRMServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CRMLite.CRMServices.Services
{
    public class LeadService : ILeadService
    {
        private ILeadRepository _leadRepository { get; set; }
        private IConfirmMessageService _confirmMessageService { get; set; }

        public LeadService(IDBContext dBContext, IConfirmMessageService confirmMessageService)
        {
            _leadRepository = dBContext.LeadRepository;
            _confirmMessageService = confirmMessageService;
        }

        public async Task<Lead> GetLeadByIdAsync(Guid Id)
        {
            try
            {
                var lead = await _leadRepository.GetLeadByIDAsync(Id);

                return lead;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> RegistrationLeadAsync(Lead lead, string path)
        {
            try
            {
                if (IsPasswordValid(lead.Password))
                {
                    lead.Password = BCrypt.Net.BCrypt.HashPassword(lead.Password);
                    lead.Id = Guid.NewGuid();
                    await _leadRepository.RegistrationLeadAsync(lead);
                    await _confirmMessageService.CreateMailConfirmationAsync(lead);

                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateLeadAsync(Lead lead)
        {
            try
            {
                await _leadRepository.UpdateLeadAsync(lead);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task DeleteLeadByIDAsync(Guid Id)
        {
            try
            {
                await _leadRepository.DeleteLeadByIDAsync(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Lead>> GetAllLeadsAsync()
        {
            try
            {
                return await _leadRepository.GetAllLeadsAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool IsPasswordValid(string password)
        {
            var regEx = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])((?=.*?[0-9])|(?=.*?[#?!@$%^&*-]))", RegexOptions.Compiled);

            return regEx.IsMatch(password);
        }
    }
}
