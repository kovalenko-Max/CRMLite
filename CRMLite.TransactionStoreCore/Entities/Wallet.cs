using System;

namespace CRMLite.TransactionStoreDomain.Entities
{
    public class Wallet
    {
        public Guid ID { get; set; }
        public Currency Currency { get; set; }
        public decimal Amount { get; set; }
    }
}
