namespace RealEx
{
	public abstract class RealExTransactionRequest : RealExBaseRequest
	{
		protected RealExTransactionRequest(string secret, string merchantId, string account, string orderId, Amount amount, Card card)
			: base(secret, merchantId, account, orderId)
		{
			SignatureProperties = () => new[] { Amount.Value.ToString(), Amount.Currency.CurrencyName(), Card.Number };
			Amount = amount;
			Card = card;
		}
		public Amount Amount { get; set; }
		public Card Card { get; set; }
	}
}