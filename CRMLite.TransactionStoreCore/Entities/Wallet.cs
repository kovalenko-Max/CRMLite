using System;
using System.Collections.Generic;
using System.Text;

namespace CRMLite.TransactionStoreCore.Entities
{
    public class Wallet
    {
        public Guid ID { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
    }
}
