using System.Xml.Serialization;

namespace RealEx
{
	[XmlRoot("request")]
	public class RealExAuthRequest : RealExTransactionRequest
	{
		internal RealExAuthRequest() { }

		public RealExAuthRequest(string secret, string merchantId, string account, string orderId, Amount amount, Card card, TssInfo tssInfo, bool autoSettle)
			: base(secret, merchantId, account, orderId, amount, card)
		{
			TssInfo = tssInfo;
			Type = "auth";
			AutoSettle = new AutoSettle(autoSettle);
		}
		[XmlElement("customernumber")]
		public string CustomerNumber { get; set; }
		[XmlElement("productid")]
		public string ProductId { get; set; }
		[XmlElement("varref")]
		public string VarRef { get; set; }
		[XmlElement("startdate")]
		public string StartDate { get; set; }
		[XmlElement("autosettle")]
		public AutoSettle AutoSettle { get; set; }
		[XmlElement("tssinfo")]
		public TssInfo TssInfo { get; set; }
	}
}