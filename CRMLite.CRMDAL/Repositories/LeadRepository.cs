using CRMLite.CRMCore.Entities;
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
            try
            {
                await _leadRepository.DeleteLeadByIDAsync(id);
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
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Lead> GetLeadByIDAsync(Guid id)
        {
            try
            {
                return await _leadRepository.GetLeadByIDAsync(id);
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
                return await _leadRepository.RegistrationLeadAsync(lead);
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
    }
}
