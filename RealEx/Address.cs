using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RealEx
{
	public abstract class Address : IXmlSerializable
	{
		private readonly string address;
		private readonly string type;

		public string Code { get; set; }
		public string Country { get; set; }

		protected Address()
		{
			
		}

		protected Address(string type, string address)
		{
			this.address = address;
			this.type = type;
		}

		public XmlSchema GetSchema()
		{
			return null;
		}

		public void ReadXml(XmlReader reader)
		{
		}

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteStartElement("address");
			writer.WriteStartAttribute("type");
			writer.WriteValue(type);
			writer.WriteEndAttribute();
			writer.WriteValue(address);
			writer.WriteEndElement();
		}
	}
}