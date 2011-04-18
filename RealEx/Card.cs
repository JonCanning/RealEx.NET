using System.Xml.Serialization;


namespace RealEx
{
	public struct Card
	{
		[XmlElement("type")]
		public RealExCardType Type { get; set; }
		[XmlElement("number")]
		public string Number { get; set; }
		[XmlElement("expdate")]
		public string ExpDate { get; set; }
		[XmlElement("chname")]
		public string ChName { get; set; }
		[XmlElement("issueno")]
		public string IssueNo { get; set; }
		[XmlElement("cvn")]
		public Cvn Cvn { get; set; }
	}
}