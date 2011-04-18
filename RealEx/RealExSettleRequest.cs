using System.Xml.Serialization;

namespace RealEx
{
	[XmlRoot("request")]
	public class RealExSettleRequest : RealExAdminRequest
	{
		internal RealExSettleRequest() { }

		public RealExSettleRequest(string secret, string merchantId, string account, string orderId, string pasRef, string authCode)
			: base(secret, merchantId, account, orderId, pasRef, authCode)
		{
			Type = "settle";
		}
	}
}