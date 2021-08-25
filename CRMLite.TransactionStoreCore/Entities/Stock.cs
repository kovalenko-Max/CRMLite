using System;

namespace CRMLite.TransactionStoreDomain.Entities
{
    public class Stock
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public bool IsDividend { get; set; }
    }
}