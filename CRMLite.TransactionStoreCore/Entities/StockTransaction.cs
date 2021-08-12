using System;

namespace CRMLite.TransactionStoreDomain.Entities
{
    public class StockTransaction
    {
        public Guid ID { get; set; }
        public bool IsDeposit { get; set; }
        public Guid StockPortfolioID { get; set; }
        public int Quantity { get; set; }
        public decimal StockPrice { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
