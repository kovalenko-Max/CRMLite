using System;

namespace CRMLite.TransactionStoreDomain.Entities
{
    public class Transaction
    {
        public string OperationName { get; set; }
        public Wallet From { get; set; }
        public Wallet To { get; set; }
        public decimal Amount { get; set; }
        public DateTime Timestamp { get; set; }
        public TransactionStatus Status { get; set; }
    }
}
