using CRMLite.CRMCore.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.CRMDAL.Interfaces
{
    public interface ILeadRepository : IRepository
    {
        Task<Lead> GetLeadByIDAsync(Guid ID);
        Task<IEnumerable<Lead>> GetAllLeadsAsync();
        Task<Guid> RegistrationLeadAsync(Lead lead);
        Task UpdateLeadAsync(Lead lead);
        Task DeleteLeadByIdAsync(Guid ID);
    }
}
