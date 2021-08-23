using System;

namespace CRMLite.RatesDAL.Models
{
    public class ExchangeRate
    {
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Code { get; set; }
        public double Value { get; set; }

        public ExchangeRate(Guid id, DateTime timestamp, string code, double val)
        {
            Id = id;
            Timestamp = timestamp;
            Code = code;
            Value = val;
        }

        public override bool Equals(object obj)
        {
            return obj is ExchangeRate rate &&
                   Id.Equals(rate.Id) &&
                   Timestamp == rate.Timestamp &&
                   Code == rate.Code &&
                   Value == rate.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Timestamp, Code, Value);
        }

        public override string ToString()
        {
            return $"{Id} {Timestamp} {Code} {Value}";
        }
    }
}