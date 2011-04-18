using System.Xml.Serialization;

namespace RealEx
{
	[XmlRoot("request")]
	public class RealExTssRequest : RealExAuthRequest
	{
		internal RealExTssRequest() { }

		public RealExTssRequest(string secret, string merchantId, string account, string orderId, Amount amount, Card card, TssInfo tssInfo, bool autoSettle)
			: base(secret, merchantId, account, orderId, amount, card, tssInfo, autoSettle)
		{
			Type = "tss";
		}
	}
}