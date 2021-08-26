namespace CRMLite.TransactionStoreAPI.PayPalHelper
{
    public class SuccessInfo
    {
        public string State { get; internal set; }
        public string PayerName { get; internal set; }
        public string Amount { get; internal set; }
    }
}
