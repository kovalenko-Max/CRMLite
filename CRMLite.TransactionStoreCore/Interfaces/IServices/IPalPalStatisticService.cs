using CRMLite.TransactionStoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IServices
{
    public interface IPalPalStatisticService
    {
        Task CreatePayPalStatisticAsync(PayPalStatistic payPalStatistic);
        Task<IEnumerable<PayPalStatistic>> GetAllPayPalStatisticAsync();
        Task<IEnumerable<PayPalStatistic>> GetPayPalStatisticByCityAsync(string city);
        Task<IEnumerable<PayPalStatistic>> GetPayPalStatisticByDayAsync(DateTime dateTime);
    }
}
