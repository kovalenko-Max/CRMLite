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

        public async Task<int> GetCountLeadsAsync()
        {
            return await _leadRepository.GetCountLeadsAsync();
        }

        public async Task<IEnumerable<Lead>> PaginateLeadsAsync(int startItem, int countItems)
        {
            if (startItem >= 0 && countItems > 0)
            {
                return await _leadRepository.PaginateLeadsAsync(startItem, countItems);
            }
            else if (startItem < 0)
            {
                throw new ArgumentException("Invalid StartItem index");
            }
            else
            {
                throw new ArgumentException("Invalid CountItem index");
            }
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
            else
            {
                throw new ArgumentNullException("Lead is null");
            }
        }

        public async Task UpdateLeadAsync(Lead lead)
        {
            if (!(lead is null))
            {
                await _leadRepository.UpdateLeadAsync(lead);
            }
            else
            {
                throw new ArgumentNullException("Lead is null");
            }
        }
        public async Task<Lead> GetLeadByEmailAsync(string email)
        {
            if (!(email is null ) && email != string.Empty)
            {
                return await _leadRepository.GetLeadByEmailAsync(email);
            }

            throw new ArgumentNullException("String Email is empty");
        }
    }
}
