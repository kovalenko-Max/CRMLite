using CRMLite.TransactionStoreDomain.Entities;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IRepositories
{
    [Sql(Schema = "CRMLite")]
    public interface ITransactionRepository : IRepository
    {
        [Recordset(typeof(TransactionDTO))]
        Task<IEnumerable<TransactionDTO>> GetAllTransactionsByLeadIDAsync(Guid leadID);
        [Recordset(typeof(TransactionDTO))]
        Task<IEnumerable<TransactionDTO>> GetAllTransactionsByWalletIDAsync(Guid walletID);
        Task CreateTransactionAsync(Transaction currentTransaction);
    }
}