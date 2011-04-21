using System.Xml.Serialization;

namespace RealEx
{
	public struct TssInfo
	{
		[XmlElement("custnum")]
		public string CustNum { get; set; }
		[XmlElement("prodid")]
		public string ProdId { get; set; }
		[XmlElement("varref")]
		public string VarRef { get; set; }
		[XmlElement("custipaddress")]
		public string CustIpAddress { get; set; }
		[XmlElement("billingaddress")]
		public BillingAddress BillingAddress { get; set; }
		[XmlElement("shippingaddress")]
		public ShippingAddress ShippingAddress { get; set; }
	}
}