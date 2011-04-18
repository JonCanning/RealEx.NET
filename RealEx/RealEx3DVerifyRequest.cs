using System.Xml.Serialization;

namespace RealEx
{
	[XmlRoot("request")]
	public class RealEx3DVerifyRequest : RealExTransactionRequest
	{
		internal RealEx3DVerifyRequest() { }

		public RealEx3DVerifyRequest(string secret, string merchantId, string account, string orderId, Amount amount, Card card, string paRes)
			: base(secret, merchantId, account, orderId, amount, card)
		{
			PaRes = paRes;
			Type = "3ds-verifysig";
			IsSecure = true;
		}

		[XmlElement("pares")]
		public string PaRes { get; set; }
	}
}