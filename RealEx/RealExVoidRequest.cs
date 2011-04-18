using System.Xml.Serialization;


namespace RealEx
{
	[XmlRoot("request")]
	public class RealExVoidRequest : RealExAdminRequest
	{
		internal RealExVoidRequest()
		{
		}

		public RealExVoidRequest(string secret, string merchantId, string account, string orderId, string pasRef, string authCode)
			: base(secret, merchantId, account, orderId, pasRef, authCode)
		{
			Type = "void";
		}
	}
}
