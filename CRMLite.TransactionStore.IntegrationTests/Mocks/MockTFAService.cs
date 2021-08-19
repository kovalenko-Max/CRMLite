using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using System;
using System.Threading.Tasks;

namespace CRMLite.TransactionStore.IntegrationTests.Mocks
{
    public class MockTFAService : ITFAService
    {
        public async Task AddTFAKeyToLeadAsync(Guid leadID, string key)
        {
            
        }

        public async Task<bool> ConfirmPinAsync(Guid leadID, string pin)
        {
            return true;
        }

        public async Task<TFAModel> GetTFAModelAsync(Guid leadID)
        {
            return new TFAModel()
            {
                ManualEntryKey = string.Empty,
                QRCodeBase64 = string.Empty
            };
        }

        public async Task<bool> IsLeadTFAExistAsync(Guid leadID)
        {
            return true;
        }

        private async Task<string> GetTFAKeyByLeadIDAsync(Guid leadID)
        {
            return string.Empty;
        }
    }
}
