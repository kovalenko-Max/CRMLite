namespace CRMLite.CRMServices.Interfaces
{
    public interface IMailExchangeService
    {
        void SendMessage(string destMail, string messageSubject, string messageBody);
    }
}
