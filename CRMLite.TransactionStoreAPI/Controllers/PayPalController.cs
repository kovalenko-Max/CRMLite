using CRMLite.TransactionStoreAPI.PayPalHelper;
using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CRMLite.TransactionStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "PermissionForAdminAndUserRoles")]
    public class PayPalController : Controller
    {
        private ITransactionService _transactioneService;
        private IWalletService _walletService;
        private IPalPalStatisticService _palPalStatisticService;
        public IConfiguration _configuration { get; set; }

        public PayPalController(IConfiguration configuration, ITransactionService transactionService, IWalletService walletService,
                IPalPalStatisticService palPalStatisticService)
        {
            _configuration = configuration;
            _transactioneService = transactionService;
            _walletService = walletService;
            _palPalStatisticService = palPalStatisticService;
        }

        [HttpPost]
        [Route("checkout")]
        public async Task<string> Checkout(decimal total, Guid leadID)
        {
            var payPalAPI = new PayPalAPI(_configuration);
            var paymentCreated = await payPalAPI.GetRedirectURLToPayPal(total, "USD");
            _transactioneService.СheckoutStarted(paymentCreated.PaymentId, leadID);
            return paymentCreated.RedirectUrl;
        }

        [Route("success")]
        public async Task<JsonResult> Success([FromQuery(Name = "paymentId")] string paymentId,
            [FromQuery(Name = "payerID")] string payedID)
        {
            var payPalAPI = new PayPalAPI(_configuration);
            PayPalPaymentExecutedResponse result = await payPalAPI.ExecutedPayment(paymentId, payedID);

            SuccessInfo successInfo = new SuccessInfo();
            successInfo.State = result.state;
            successInfo.PayerName = result.payer.payer_Info.first_name + " " + result.payer.payer_Info.last_name;
            successInfo.Amount = result.transactions[0].amount.total;

            if (result.state == "approved")
            {
                var userID = _transactioneService.GetCheckoutUserGuid(paymentId);

                PayPalStatistic payPalStatistic = new PayPalStatistic()
                {
                    ID = Guid.NewGuid(),
                    LeadID = userID,
                    first_name = result.payer.payer_Info.first_name,
                    last_name = result.payer.payer_Info.last_name,
                    email = result.payer.payer_Info.email,
                    total = result.transactions[0].amount.total,
                    currency = result.transactions[0].amount.currency,
                    city = result.payer.payer_Info.shipping_Address.city,
                    state = result.payer.payer_Info.shipping_Address.state,
                    postal_code = result.payer.payer_Info.shipping_Address.postal_code,
                    country_code = result.payer.payer_Info.shipping_Address.country_code,
                    intent = result.intent,
                    create_time = result.create_time,
                    payment_mode = result.transactions[0].related_Resources[0].sale.payment_mode,
                    recipient_name = result.transactions[0].item_List.shipping_Address.recipient_name
                };

                var amount = decimal.Parse(successInfo.Amount,
                    NumberStyles.AllowDecimalPoint,
                    CultureInfo.InvariantCulture);
                var payPalWallet = await _walletService.GetPayPalWalletAsync();
                var defaultUserWallet = await _walletService.GetUSDWalletByLeadIDAsync(userID);

                var payPalTransaction = new Transaction()
                {
                    ID = Guid.NewGuid(),
                    Amount = amount,
                    LeadID = userID,
                    Timestamp = DateTime.Now,
                    OperationType = new OperationType()
                    {
                        ID = 1,
                        Type = ""
                    },
                    WalletFrom = payPalWallet,
                    WalletTo = defaultUserWallet
                };

                await _transactioneService.CreateTransactionAsync(payPalTransaction);
                await _palPalStatisticService.CreatePayPalStatisticAsync(payPalStatistic);
            }

            return Json(successInfo);
        }
    }
}
