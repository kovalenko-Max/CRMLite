using System;

namespace CRMLite.TransactionStoreDomain.Entities
{
    public class PayPalStatistic
    {
        public Guid ID { get; set; }
        public Guid LeadID { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string total { get; set; }
        public string currency { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postal_code { get; set; }
        public string country_code { get; set; }
        public string intent { get; set; }
        public DateTime create_time { get; set; }
        public string payment_mode { get; set; }
        public string recipient_name { get; set; }
    }
}
