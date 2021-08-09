﻿using CRMLite.CRMCore.Entities;
using CRMLite.CRMDAL.Interfaces;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CRMLite.CRMDAL.Repositories
{
    public class LeadRepository : ILeadRepository
    {
        private readonly ILeadRepository _leadRepository;
        public IDbConnection DBConnection { get; }

        public LeadRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _leadRepository = DBConnection.As<ILeadRepository>();
        }

        public async Task DeleteLeadByIDAsync(Guid id)
        {
            if (id != Guid.Empty)
            {
                await _leadRepository.DeleteLeadByIDAsync(id);
            }
            else
            {
                throw new ArgumentException("Guid is empty");
            }
        }

        public async Task<IEnumerable<Lead>> GetAllLeadsAsync()
        {
            return await _leadRepository.GetAllLeadsAsync();
        }

        public async Task<Lead> GetLeadByIDAsync(Guid id)
        {
            if (id != Guid.Empty)
            {
                return await _leadRepository.GetLeadByIDAsync(id);
            }

            throw new ArgumentException("Guid is empty");
        }

        public async Task RegistrationLeadAsync(Lead lead)
        {
            if (!(lead is null))
            {
                await _leadRepository.RegistrationLeadAsync(lead);
            }

            throw new ArgumentNullException("Lead is null");
        }

        public async Task UpdateLeadAsync(Lead lead)
        {
            if (!(lead is null))
            {
                await _leadRepository.UpdateLeadAsync(lead);
            }

            throw new ArgumentNullException("Lead is null");
        }
        public async Task<Lead> GetLeadByEmailAsync(string email)
        {
            if (!(email is null))
            {
                return await _leadRepository.GetLeadByEmailAsync(email);
            }

            throw new ArgumentNullException("Email is null");
        }
    }
}
