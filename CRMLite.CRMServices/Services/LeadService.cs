﻿using CRMLite.CRMCore.Entities;
using CRMLite.CRMDatabase.Interfaces;
using CRMLite.CRMServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.CRMServices.Services
{
    public class LeadService : ILeadService
    {
        private ILeadRepository _leadRepository { get; set; }

        public LeadService(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        public async Task<Lead> GetLeadByIdAsync(Guid Id)
        {
            try
            {
                var lead = await _leadRepository.GetLeadByID(Id);

                return lead;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Guid> RegistrationLeadAsync(Lead lead)
        {
            try
            {
                lead.Id = Guid.NewGuid();
                await _leadRepository.RegistrationLead(lead);

                return lead.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async void UpdateLeadAsync(Lead lead)
        {
            try
            {
                await _leadRepository.UpdateLead(lead);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async void DeleteLeadByIdAsync(Guid Id)
        {
            try
            {
                await _leadRepository.DeleteLeadById(Id);
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
                return await _leadRepository.GetAllLeads();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
