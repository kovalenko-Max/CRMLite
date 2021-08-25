using CRMLite.CRMCore.Entities;
using CRMLite.CRMServices.Interfaces;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace CRMLite.CRMServices.Services
{
    public class MailExchangeService : IMailExchangeService
    {
        private readonly SmtpOption _smtpOption;

        public MailExchangeService(IOptions<SmtpOption> smtpOptions)
        {
            _smtpOption = smtpOptions.Value;
        }

        public void SendMessage(string destMail, string messageSubject, string messageBody)
        {
            var from = new MailAddress(_smtpOption.SenderMail, _smtpOption.SenderName);

            var client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_smtpOption.SenderMail, _smtpOption.SenderPassword)
            };

            string button = $"<a href=\"{messageBody}\"><button >Confirm registration</button></a>";
            var to = new MailAddress(destMail);
            var massage = new MailMessage(from, to)
            {
                Body = button,
                Subject = messageSubject
            };
            massage.IsBodyHtml = true;

            client.Send(massage);
        }
    }
}
