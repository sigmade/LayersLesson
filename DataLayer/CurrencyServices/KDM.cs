namespace DataLayer.CurrencyServices
{
    public class KDM : ICurrenceExchange
    {
        public decimal GetCoeff()
        {
            return 0.7M;
        }
    }
}
