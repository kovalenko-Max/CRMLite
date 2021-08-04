using System;
using System.Collections.Generic;

namespace CRMLite.TransactionStoreDomain.Entities
{
    public class StockPortfolio
    {
        public Guid ID { get; set; }
        public Guid LeadID { get; set; }
        public Stock Stocks { get; set; }
        public int Quantity { get; set; }
    }
}
