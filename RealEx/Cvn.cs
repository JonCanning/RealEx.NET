using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;


namespace RealEx
{
	public struct Cvn : IXmlSerializable
	{
		[XmlElement("number")]
		public string Number { get; set; }
		[XmlElement("presind")]
		public PresInd PresInd { get; set; }
		public XmlSchema GetSchema()
		{
			return null;
		}

		public void ReadXml(XmlReader reader)
		{
		}

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteStartElement("number");
			writer.WriteValue(Number);
			writer.WriteEndElement();
			if ((int)PresInd != 0)
			{
				writer.WriteStartElement("presind");
				writer.WriteValue((int)PresInd);
				writer.WriteEndElement();
			}
		}
	}
}