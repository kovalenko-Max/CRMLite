namespace CRMLite.TransactionStoreAPI.PayPalHelper
{
    public class PaymentCreated
    {
        public string PaymentId { get; internal set; }
        public string RedirectUrl { get; internal set; }
    }
}