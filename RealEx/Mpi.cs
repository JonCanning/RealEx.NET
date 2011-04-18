using System.Xml.Serialization;


namespace RealEx
{
	public struct Mpi
	{
		public Mpi(string cavv, string xid, string eci)
			: this()
		{
			Cavv = cavv;
			Xid = xid;
			Eci = eci;
		}
		[XmlElement("eci")]
		public string Eci { get; set; }
		[XmlElement("xid")]
		public string Xid { get; set; }
		[XmlElement("cavv")]
		public string Cavv { get; set; }
	}
}