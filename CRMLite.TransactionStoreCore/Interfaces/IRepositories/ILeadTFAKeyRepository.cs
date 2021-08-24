using Insight.Database;
using System;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IRepositories
{
    [Sql(Schema ="[CRMLite]")]
    public interface ILeadTFAKeyRepository
    {
        Task AddTFAKeyToLeadAsync(Guid leadID, string key);
        Task<string> GetTFAKeyByLeadIDAsync(Guid leadID);
        Task<bool> GetIsExistTFAByLeadIDAsync(Guid leadID);
        Task SetExistTFAByLeadIDAsync(Guid leadID);
    }
}
