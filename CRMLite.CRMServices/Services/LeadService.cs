using CRMLite.CRMCore.Entities;
using CRMLite.CRMDAL.Interfaces;
using CRMLite.CRMServices.Interfaces;
using System;
using System.Collections.Generic;
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
            if (Id != Guid.Empty)
            {
                return await _leadRepository.GetLeadByIDAsync(Id);
            }

            throw new ArgumentException("Guid leadID is empty");
        }

        public async Task<Lead> LoginAsync(AuthentificationModel authenticationModel)
        {
            if (!(authenticationModel is null))
            {
                return await _leadRepository.GetLeadByEmailAsync(authenticationModel.Email);
            }

            throw new ArgumentNullException("AuthentificationModel is null");
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

        public async Task DeleteLeadByIDAsync(Guid Id)
        {
            if (Id != Guid.Empty)
            {
                await _leadRepository.DeleteLeadByIDAsync(Id);
            }
            else
            {
                throw new ArgumentException("Guid Id is empty");
            }
        }

        public async Task<IEnumerable<Lead>> GetAllLeadsAsync()
        {
            return await _leadRepository.GetAllLeadsAsync();
        }

        public async Task<IEnumerable<Lead>> PaginateLeadsAsync(int startItem, int countItems)
        {
            if (startItem >= 0 && countItems > 0)
            {
                return await _leadRepository.PaginateLeadsAsync(startItem, countItems);
            }
            else if(startItem < 0)
            {
                throw new ArgumentException("Invalid StartItem index");
            }
            else
            {
                throw new ArgumentException("Invalid CountItem index");
            }
        }
    }
}
