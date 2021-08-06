using CRMLite.CRMCore.Entities;
using CRMLite.CRMDAL.Interfaces;
using CRMLite.CRMServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CRMLite.CRMServices.Services
{
    public class LeadService : ILeadService
    {
        private ILeadRepository _leadRepository { get; set; }

        public LeadService(IDBContext dBContext)
        {
            _leadRepository = dBContext.LeadRepository;
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

        public async Task<Lead> LoginAsync(AuthentificationModel authenticationModel)
        {
            try
            {
                var lead = await _leadRepository.GetLeadByEmailAsync(authenticationModel.Email);

                return lead;
            }
            catch (Exception e)
            {
                throw e;
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

        public async Task DeleteLeadByIdAsync(Guid Id)
        {
            try
            {
                await _leadRepository.DeleteLeadByIdAsync(Id);
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
    }
}
