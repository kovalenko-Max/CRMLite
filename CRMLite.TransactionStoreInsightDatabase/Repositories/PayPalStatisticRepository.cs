using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreInsightDatabase.Repositories
{
    [Sql(Schema = "CRMLite")]
    public class PayPalStatisticRepository : IPalPalStatisticRepository
    {
        public IDbConnection DBConnection { get; }
        private IPalPalStatisticRepository _palPalStatisticRepository;
        public PayPalStatisticRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _palPalStatisticRepository = dbConnection.As<IPalPalStatisticRepository>();
        }
        public async Task CreatePayPalStatisticAsync(PayPalStatistic payPalStatistic)
        {
            if (payPalStatistic != null)
            {
                await _palPalStatisticRepository.CreatePayPalStatisticAsync(payPalStatistic);
            }
            else
            {
                throw new ArgumentNullException("PayPalStatistic is null");
            }
        }
        public async Task<IEnumerable<PayPalStatistic>> GetAllPayPalStatisticAsync()
        {
            var response = await _palPalStatisticRepository.GetAllPayPalStatisticAsync();

            return response;
        }
        public async Task<IEnumerable<PayPalStatistic>> GetPayPalStatisticByCityAsync(string city)
        {
            var response = await _palPalStatisticRepository.GetPayPalStatisticByCityAsync(city);

            return response;
        }
        public async Task<IEnumerable<PayPalStatistic>> GetPayPalStatisticByDayAsync(DateTime dateTime)
        {
            var response = await _palPalStatisticRepository.GetPayPalStatisticByDayAsync(dateTime);

            return response;
        }
    }
}
