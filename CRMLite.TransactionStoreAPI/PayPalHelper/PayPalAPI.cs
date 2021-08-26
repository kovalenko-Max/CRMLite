using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreAPI.PayPalHelper
{
    public class PayPalAPI
    {
        public IConfiguration _configuration { get; set; }
        public PayPalAPI(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<PaymentCreated> GetRedirectURLToPayPal(decimal total, string currency)
        {
            try
            {
                return Task.Run(async () =>
                {
                    HttpClient http = GetPaypalHttpClient();
                    PayPalAccessToken accessToken = await GetPayPalAccessTokenAsync(http);
                    PayPalPaymentCreatedResponse createdPaymentRsp = await CreatePaypalPaymentAsync
                            (http, accessToken, total, currency);
                    PaymentCreated paymentCreated = new PaymentCreated();
                    paymentCreated.PaymentId = createdPaymentRsp.id;
                    paymentCreated.RedirectUrl = createdPaymentRsp.links.First(x => x.rel == "approval_url").href;
                    return paymentCreated;
                }).Result;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e, "Error to login to PalPal");
                return null;
            }
        }
        public async Task<PayPalPaymentExecutedResponse> ExecutedPayment(string paymentId, string payerId)
        {
            try
            {
                HttpClient http = GetPaypalHttpClient();
                PayPalAccessToken accessToken = await GetPayPalAccessTokenAsync(http);

                return await ExecutePaypalPaymentAsync(http, accessToken, paymentId, payerId);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e, "Failed to login to PalPal");

                return null;
            }
        }
        public HttpClient GetPaypalHttpClient()
        {
            string sandbox = _configuration["PayPal:urlAPI"];
            var http = new HttpClient
            {
                BaseAddress = new Uri(sandbox),
                Timeout = TimeSpan.FromSeconds(30),
            };

            return http;
        }
        public async Task<PayPalAccessToken> GetPayPalAccessTokenAsync(HttpClient http)
        {
            byte[] bytes = Encoding.GetEncoding("iso-8859-1").GetBytes($"{_configuration["PayPal:clientId"]}:{_configuration["PayPal:secret"]}");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/v1/oauth2/token");
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(bytes));
            var form = new Dictionary<string, string>
            {
                ["grant_type"] = "client_credentials"
            };

            request.Content = new FormUrlEncodedContent(form);
            HttpResponseMessage response = await http.SendAsync(request);
            string content = await response.Content.ReadAsStringAsync();
            PayPalAccessToken accessToken = JsonConvert.DeserializeObject<PayPalAccessToken>(content);

            return accessToken;
        }
        public async Task<PayPalPaymentCreatedResponse> CreatePaypalPaymentAsync(HttpClient http,
            PayPalAccessToken accessToken, decimal total, string _currency)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "v1/payments/payment");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.access_token);

            var payment = JObject.FromObject(new
            {
                intent = "sale",
                redirect_urls = new
                {
                    return_url = _configuration["PayPal:returnUrl"],
                    cancel_url = _configuration["PayPal:cancelUrl"]
                },
                payer = new { payment_method = "paypal" },
                transactions = JArray.FromObject(new[]
                {
                    new
                    {
                        amount = new
                        {

                            total = total,
                            currency = _currency
                        }
                    }
                })
            });

            string content1 = JsonConvert.SerializeObject(payment);
            request.Content = new StringContent(content1,
                Encoding.UTF8, "application/json");

            HttpResponseMessage response = await http.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            PayPalPaymentCreatedResponse payPalPaymentCreated =
                JsonConvert.DeserializeObject<PayPalPaymentCreatedResponse>(content);

            return payPalPaymentCreated;
        }

        public async Task<PayPalPaymentExecutedResponse> ExecutePaypalPaymentAsync(HttpClient http,
            PayPalAccessToken accessToken, string paymentId, string payerId)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post,
                $"v1/payments/payment/{paymentId}/execute");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer",
                accessToken.access_token);

            var payment = JObject.FromObject(
                new
                {
                    payer_id = payerId
                });

            request.Content = new StringContent(JsonConvert.SerializeObject(payment),
                Encoding.UTF8, "application/json");

            HttpResponseMessage response = await http.SendAsync(request);
            string content = await response.Content.ReadAsStringAsync();
            PayPalPaymentExecutedResponse executedPayment =
                JsonConvert.DeserializeObject<PayPalPaymentExecutedResponse>(content);

            return executedPayment;
        }

    }
}
