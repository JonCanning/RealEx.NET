namespace RealEx
{
    public abstract class RealExTransactionRequest : RealExBaseRequest
    {
        protected RealExTransactionRequest(string secret, string merchantId, string account, string orderId, Amount amount, Card card, Comments comments)
            : base(secret, merchantId, account, orderId, comments)
        {
            SignatureProperties = () => new[] { Amount.Value.ToString(), Amount.Currency.CurrencyName(), Card.Number };
            Amount = amount;
            Card = card;
        }
        public Amount Amount { get; private set; }
        public Card Card { get; private set; }
    }
}