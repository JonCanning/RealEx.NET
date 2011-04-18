using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RealEx
{
	public abstract class RealExBaseRequest
	{
		protected RealExBaseRequest() { }

		protected RealExBaseRequest(string secret, string merchantId, string account, string orderId)
		{
			TimeStamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
			OrderId = orderId;
			MerchantId = merchantId;
			Account = account;
			Secret = secret;
		}
		[XmlAttribute("type")]
		public string Type { get; set; }
		[XmlAttribute("timestamp")]
		public string TimeStamp { get; set; }
		[XmlElement("orderid")]
		public string OrderId { get; set; }
		[XmlElement("merchantid")]
		public string MerchantId { get; set; }
		[XmlElement("account")]
		public string Account { get; set; }
		[XmlElement("comments")]
		public Comments Comments { get; set; }
		[XmlElement("sha1hash")]
		public string Sha1Hash { get; set; }
		[XmlIgnore]
		internal Func<IEnumerable<string>> SignatureProperties { get; set; }
		[XmlIgnore]
		public string Secret { get; set; }
		[XmlIgnore]
		internal bool IsSecure { get; set; }
	}
}
