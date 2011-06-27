namespace RealEx
{
    public class Amount
    {
        public Amount(decimal value, RealExCurrency currency)
        {
            Value = value * 100;
            Currency = currency;
        }

        public decimal Value { get; private set; }
        public RealExCurrency Currency { get; private set; }
    }
}