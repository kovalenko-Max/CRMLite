namespace CRMLite.RatesService.RandomRates
{
    public struct ExchangeRandomModel
    {
        public string Code { get; set; }
        public double MinRandomValue { get; set; }
        public double MaxRandomvalue { get; set; }

        public ExchangeRandomModel(string code, double lessRandomValue, double maxRandomvalue)
        {
            Code = code;
            MinRandomValue = lessRandomValue;
            MaxRandomvalue = maxRandomvalue;
        }
    }
}