using System.Xml.Serialization;

namespace RealEx
{
	[XmlRoot("request")]
	public class RealEx3DEnrolledRequest : RealExTransactionRequest
	{
		internal RealEx3DEnrolledRequest() { }

		public RealEx3DEnrolledRequest(string secret, string merchantId, string account, string orderId, Amount amount, Card card)
			: base(secret, merchantId, account, orderId, amount, card)
		{
			Type = "3ds-verifyenrolled";
			IsSecure = true;
		}
	}
}