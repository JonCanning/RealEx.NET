using System.Xml.Serialization;

namespace RealEx
{
	public abstract class RealExAdminRequest : RealExBaseRequest
	{
		internal RealExAdminRequest(){}

		internal RealExAdminRequest(string secret, string merchantId, string account, string orderId, string pasRef, string authCode)
			: base(secret, merchantId, account, orderId)
		{
			PasRef = pasRef;
			AuthCode = authCode;
		}

		[XmlElement("pasref")]
		public string PasRef { get; set; }
		[XmlElement("authcode")]
		public string AuthCode { get; set; }
	}
}