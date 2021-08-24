using CRMLite.CRMCore.Entities;
using CRMLite.CRMDAL.Interfaces;
using CRMLite.CRMServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRMLite.Core.Pagination;
using CRMLite.CRMCore.Helper;

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

        public async Task<PaginationModel<Lead>> PaginateLeadsAsync(int currentPage)
        {
            var pageLimit = 2;
            var startItem = (currentPage - 1) * pageLimit;
            var countLeads = await GetCountLeadsAsync();
            var leads = await _leadRepository.PaginateLeadsAsync(startItem, pageLimit);
            var paginationModel = new PaginationModel<Lead>()
            {
                CountItems = countLeads,
                PageLimit = pageLimit,
                Items = leads
            };

            return paginationModel;
        }

        public async Task<int> GetCountLeadsAsync()
        {
            return await _leadRepository.GetCountLeadsAsync();
        }
    }
}
