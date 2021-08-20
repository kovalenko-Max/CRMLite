using CRMLite.RatesDAL.Repositories;
using System.Data;
using System.Threading;
using System.Data.SqlClient;
using CRMLite.RatesService.RandomRates;

namespace CRMLite.RatesService
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString =
                "Data Source=crmlitedb.database.windows.net;User ID=Maks;Initial Catalog=CRMLite.RatesDB;Password=Qwerty12#;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            IDbConnection currencyDbConnection = new SqlConnection(connectionString);
            IDbConnection stockDbConnection = new SqlConnection(connectionString);
                
            RateGenerator currencyRateGenerator 
                = new RateGenerator(new CurrencyRateRepository(currencyDbConnection), new StockRateRepository(stockDbConnection));

            while (true)
            {
                currencyRateGenerator.CreateStockExchangeService();
                currencyRateGenerator.CreateCurrencyExchangeRates();

                Thread.Sleep(5000);
            }
        }
    }
}