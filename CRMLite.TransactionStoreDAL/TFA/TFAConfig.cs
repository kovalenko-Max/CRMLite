using System;

namespace CRMLite.TransactionStoreBLL.TFA
{
    public class TFAConfig
    {
        public string SecretString { get; set; }
        public string AccountTitle { get; set; }
        public string ApplicationName { get; set; }
        public bool SecretISBase32 { get; set; }
        public int SizeQRCode { get; set; }
        public int TimeDriftInMinute { get; set; }

        public TimeSpan GetTimeDrift()
        {
            var hour = TimeDriftInMinute % 60;

            return new TimeSpan(hour, TimeDriftInMinute, 0);
        }
    }
}
