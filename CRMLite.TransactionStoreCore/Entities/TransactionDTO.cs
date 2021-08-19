using System;

namespace CRMLite.TransactionStoreDomain.Entities
{
    public class TransactionDTO
    {
        public Guid ID { get; set; }
        public Guid LeadID { get; set; }
        public decimal Amount { get; set; }
        public DateTime Timestamp { get; set; }

        public Guid WalletFromID { get; set; }
        public decimal WalletFromAmount { get; set; }
        public int CurrencyFromID { get; set; }
        public string CurrencyFromCode { get; set; }
        public string CurrencyFromTitle { get; set; }

        public Guid WalletToID { get; set; }
        public decimal WalletToAmount { get; set; }
        public int CurrencyToID { get; set; }
        public string CurrencyToCode { get; set; }
        public string CurrencyToTitle { get; set; }

        public byte OperationTypeID { get; set; }
        public string OperationTypeType { get; set; }
    }
}