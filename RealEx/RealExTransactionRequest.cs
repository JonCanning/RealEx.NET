using System.Xml.Serialization;

namespace RealEx
{
	public abstract class RealExTransactionRequest : RealExBaseRequest
	{
		internal RealExTransactionRequest()
		{

		}
		protected RealExTransactionRequest(string secret, string merchantId, string account, string orderId, Amount amount, Card card)
			: base(secret, merchantId, account, orderId)
		{
			SignatureProperties = () => new[] { Amount.Value.ToString(), Amount.Currency.CurrencyName(), Card.Number };
			Amount = amount;
			Card = card;
		}
		[XmlElement("amount")]
		public Amount Amount { get; set; }
		[XmlElement("card")]
		public Card Card { get; set; }
	}
}