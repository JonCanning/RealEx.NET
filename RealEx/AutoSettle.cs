using System.Xml.Serialization;

namespace RealEx
{
	public struct AutoSettle
	{
		public AutoSettle(bool flag)
			: this()
		{
			Flag = flag ? "1" : "0";
		}
		[XmlAttribute("flag")]
		public string Flag { get; set; }
	}
}