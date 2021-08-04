﻿using CRMLite.CRMCore.Entities;
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

        public async Task<bool> RegistrationLeadAsync(Lead lead, string path)
        {
            try
            {
                if (IsPasswordValid(lead.Password))
                {
                    lead.Password = BCrypt.Net.BCrypt.HashPassword(lead.Password);
                    lead.Id = Guid.NewGuid();
                    await _leadRepository.RegistrationLeadAsync(lead);

                    return true;
                }
                return false;
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
                await _leadRepository.UpdateLeadAsync(lead);
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

        private bool IsPasswordValid(string password)
        {
            var regEx = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])((?=.*?[0-9])|(?=.*?[#?!@$%^&*-]))", RegexOptions.Compiled);

            return regEx.IsMatch(password);
        }
    }
}
