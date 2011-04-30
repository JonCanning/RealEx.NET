namespace RealEx
{
    public class Amount
    {
        public Amount(decimal value, RealExCurrency currency)
        {
            Value = value;
            Currency = currency;
        }

        public decimal Value { get; set; }
        public RealExCurrency Currency { get; set; }
    }
}