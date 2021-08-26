using CRMLite.TransactionStoreDomain.Entities;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IRepositories
{
    [Sql(Schema = "[CRMLite]")]
    public interface IPalPalStatisticRepository
    {
        Task CreatePayPalStatisticAsync(PayPalStatistic payPalStatistic);
        Task<IEnumerable<PayPalStatistic>> GetAllPayPalStatisticAsync();
        Task<IEnumerable<PayPalStatistic>> GetPayPalStatisticByCityAsync(string city);
        Task<IEnumerable<PayPalStatistic>> GetPayPalStatisticByDayAsync(DateTime dateTime);


    }
}
