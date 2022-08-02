namespace DataLayer.CurrencyServices
{
    public class Mig : ICurrenceExchange
    {
        public decimal GetCoeff()
        {
            return 0.85M;
        }
    }
}
