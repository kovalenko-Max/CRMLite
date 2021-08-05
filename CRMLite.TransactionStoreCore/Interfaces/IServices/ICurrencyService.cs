using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IServices
{
    public interface ICurrencyService
    {
        Task<List<string>> GetAllCurrencyAsync();
    }
}
