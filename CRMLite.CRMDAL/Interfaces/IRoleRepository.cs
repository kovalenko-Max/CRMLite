using CRMLite.CRMCore;
using Insight.Database;
using System;
using System.Threading.Tasks;

namespace CRMLite.CRMDAL.Interfaces
{
    [Sql(Schema = "CRMLite")]
    public interface IRoleRepository:IRepository
    {
        Task<Roles> GetAllRollesByIdAsync(Guid id);
        Task DeleteLeadRoleByIdAsync(Guid id);
        Task AddRolesToLeadAsync(Guid leadId, Guid roleId);

    }
}
