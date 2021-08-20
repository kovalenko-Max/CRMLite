using System;

namespace CRMLite.TransactionStoreDomain.Entities
{
    public class Transaction
    {
        public Guid ID { get; set; }
        public Guid LeadID { get; set; }
        public string OperationType { get; set; }
        public decimal Amount { get; set; }
        public DateTime Timestamp { get; set; }
        public Wallet WalletFrom { get; set; }
        public Wallet WalletTo { get; set; }
    }
}