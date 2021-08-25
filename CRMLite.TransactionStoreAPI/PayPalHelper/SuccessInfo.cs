using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreAPI.PayPalHelper
{
    public class SuccessInfo
    {
        public string State { get; internal set; }
        public string PayerName { get; internal set; }
        public string Amount { get; internal set; }
    }
}
