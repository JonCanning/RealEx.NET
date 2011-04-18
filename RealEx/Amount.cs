using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;


namespace RealEx
{
	public struct Amount : IXmlSerializable
	{
		public decimal Value { get; set; }
		public RealExCurrency Currency { get; set; }

		public XmlSchema GetSchema()
		{
			return null;
		}

		public void ReadXml(XmlReader reader)
		{
		}

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteStartAttribute("currency");
			writer.WriteValue(Enum.GetName(typeof(RealExCurrency), Currency));
			writer.WriteEndAttribute();
			writer.WriteValue(Value);
		}
	}
}