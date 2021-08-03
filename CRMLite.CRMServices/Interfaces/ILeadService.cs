using CRMLite.CRMCore.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.CRMServices.Interfaces
{
    public interface ILeadService
    {
        public Task<Lead> GetLeadByIdAsync(Guid Id);
        public Task<Guid> RegistrationLeadAsync(Lead lead);
        public void UpdateLeadAsync(Lead lead);
        public void DeleteLeadByIdAsync(Guid Id);
        public Task<IEnumerable<Lead>> GetAllLeadsAsync();
    }
}
