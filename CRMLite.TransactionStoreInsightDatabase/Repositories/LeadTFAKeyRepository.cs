using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using Insight.Database;
using System;
using System.Data;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreInsightDatabase.Repositories
{
    public class LeadTFAKeyRepository : ILeadTFAKeyRepository
    {
        private readonly ILeadTFAKeyRepository _leadTFAKeyRepository;
        public IDbConnection DBConnection { get; }

        public LeadTFAKeyRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _leadTFAKeyRepository = DBConnection.As<ILeadTFAKeyRepository>();
        }

        public async Task AddTFAKeyToLeadAsync(Guid leadID, string key)
        {
            if (leadID != Guid.Empty && key != null)
            {
                await _leadTFAKeyRepository.AddTFAKeyToLeadAsync(leadID, key);
            }
            else if (leadID == Guid.Empty)
            {
                throw new ArgumentException("Guid leadID is empty");
            }

            throw new ArgumentNullException("String key is null");
        }

        public async Task<string> GetTFAKeyByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                var key = await _leadTFAKeyRepository.GetTFAKeyByLeadIDAsync(leadID);

                return key;
            }

            throw new ArgumentException("Guid leadID is empty");
        }
    }
}
