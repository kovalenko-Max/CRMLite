using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CRMLite.TransactionStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "PermissionForAdminAndUserRoles")]
    public class PayPalStatisticController : Controller
    {
        private readonly IPalPalStatisticService _palPalStatisticService;

        public PayPalStatisticController(IPalPalStatisticService palPalStatisticService)
        {
            _palPalStatisticService = palPalStatisticService;
        }

        [HttpGet]
        public Task<IEnumerable<PayPalStatistic>> GetAllPayPalStatisticAsync()
        {
            var response = _palPalStatisticService.GetAllPayPalStatisticAsync();

            return response;
        }

        [HttpGet("city")]
        public Task<IEnumerable<PayPalStatistic>> GetPayPalStatisticByCityAsync(string city)
        {
            var response = _palPalStatisticService.GetPayPalStatisticByCityAsync(city);

            return response;
        }

        [HttpGet("dateTime")]
        public Task<IEnumerable<PayPalStatistic>> GetPayPalStatisticByDayAsync(DateTime dateTime)
        {
            var response = _palPalStatisticService.GetPayPalStatisticByDayAsync(dateTime);

            return response;
        }
    }
}
