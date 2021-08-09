using CRMLite.CRMCore.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.CRMServices.Interfaces
{
    public interface ILeadService
    {
        public Task<Lead> GetLeadByIdAsync(Guid Id);
        public Task UpdateLeadAsync(Lead lead);
        public Task DeleteLeadByIDAsync(Guid Id);
        public Task<IEnumerable<Lead>> GetAllLeadsAsync();
        public Task<Lead> LoginAsync(AuthentificationModel authenticationModel);
    }
}
