using System.Xml.Serialization;

namespace RealEx
{
	public abstract class Address
	{
		protected Address(string type)
		{
			Type = type;
		}
		[XmlElement("code")]
		public string Code { get; set; }
		[XmlElement("country")]
		public string Country { get; set; }
		[XmlAttribute("type")]
		public string Type { get; set; }
	}
}