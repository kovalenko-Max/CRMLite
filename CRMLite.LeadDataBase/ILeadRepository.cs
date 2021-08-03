using CRMLite.CRMCore.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.CRMDatabase.Interfaces
{
    public interface ILeadRepository
    {
        Task<Lead> GetLeadByID(Guid ID);
        Task<IEnumerable<Lead>> GetAllLeads();
        Task<Guid> RegistrationLead(Lead lead);
        Task<bool> UpdateLead(Lead lead);
        Task<bool> DeleteLeadById(Guid ID);
    }
}
