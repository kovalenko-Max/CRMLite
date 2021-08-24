using CRMLite.CRMCore.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRMLite.Core.Pagination;

namespace CRMLite.CRMServices.Interfaces
{
    public interface ILeadService
    {
        public Task<Lead> GetLeadByIdAsync(Guid Id);
        public Task UpdateLeadAsync(Lead lead);
        public Task DeleteLeadByIDAsync(Guid Id);
        public Task<IEnumerable<Lead>> GetAllLeadsAsync();
        public Task<int> GetCountLeadsAsync();
        public Task<PaginationModel<Lead>> PaginateLeadsAsync(int currentPage);
    }
}
