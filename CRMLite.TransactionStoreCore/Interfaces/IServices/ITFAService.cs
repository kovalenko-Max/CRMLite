using CRMLite.TransactionStoreDomain.Entities;
using System;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IServices
{
    public interface ITFAService
    {
        Task<bool> IsLeadTFAExistAsync(Guid leadID);
        Task<TFAModel> GetTFAModelAsync(Guid leadID);
        Task AddTFAKeyToLeadAsync(Guid leadID, string key);
        Task<bool> ConfirmPinAsync(Guid leadID, string pin);
    }
}
