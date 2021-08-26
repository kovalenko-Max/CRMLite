using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreBLL.Services
{
    public class PayPalStatisticService : IPalPalStatisticService
    {
        private IPalPalStatisticRepository _palPalStatisticRepository;
        public PayPalStatisticService(IPalPalStatisticRepository palPalStatisticRepository)
        {
            _palPalStatisticRepository = palPalStatisticRepository;
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

