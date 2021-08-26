using System;

namespace CRMLite.TransactionStoreDomain.RestSharp.RatesApi
{
    public class ExchangeRate
    {
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Code { get; set; }
        public decimal Value { get; set; }
    }
}
