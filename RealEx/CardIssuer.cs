using System.Xml.Serialization;


namespace RealEx
{
	public struct CardIssuer
	{
		[XmlElement("bank")]
		public string Bank { get; set; }
		[XmlElement("country")]
		public string Country { get; set; }
		[XmlElement("region")]
		public string Region { get; set; }
		[XmlElement("countrycode")]
		public string CountryCode { get; set; }
	}
}