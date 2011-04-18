using System.Xml.Serialization;

namespace RealEx
{
	[XmlRoot("request")]
	public class RealExRebateRequest : RealExAdminRequest
	{
		public RealExRebateRequest() { }

		public RealExRebateRequest(string secret, string merchantId, string account, string orderId, Amount amount, string pasRef, string authCode, string refundPassword, bool autoSettle = false)
			: base(secret, merchantId, account, orderId, pasRef, authCode)
		{
			SignatureProperties = () => new[] { Amount.Value.ToString(), Amount.Currency.CurrencyName() + "." };
			Type = "rebate";
			AutoSettle = new AutoSettle(autoSettle);
			RefundHash = XmlSerializer.ComputeHash(refundPassword);
			Amount = amount;
		}
		[XmlElement("refundhash")]
		public string RefundHash { get; set; }
		[XmlElement("autosettle")]
		public AutoSettle AutoSettle { get; set; }
		[XmlElement("amount")]
		public Amount Amount { get; set; }
	}
}
