using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMLite.CRMServices.Interfaces
{
    public interface IMailExchangeService
    {
        void SendMessage(string destMail, string messageSubject, string messageBody);
    }
}
