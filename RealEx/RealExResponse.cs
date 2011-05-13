using System.Xml.Linq;
using System.Xml.Serialization;

namespace RealEx
{
	[XmlRoot("response")]
	public class RealExResponse
	{
		[XmlElement("result")]
		public string Result { get; set; }
		[XmlElement("message")]
		public string Message { get; set; }
		[XmlElement("pasref")]
		public string PasRef { get; set; }
		[XmlElement("authcode")]
		public string AuthCode { get; set; }
		[XmlElement("pareq")]
		public string PaReq { get; set; }
		[XmlElement("enrolled")]
		public string Enrolled { get; set; }
		[XmlElement("xid")]
		public string Xid { get; set; }
		[XmlElement("orderid")]
		public string OrderId { get; set; }
		[XmlElement("sha1hash")]
		public string Sha1Hash { get; set; }
		[XmlElement("merchantid")]
		public string MerchantId { get; set; }
		[XmlElement("account")]
		public string Account { get; set; }
		[XmlElement("timetaken")]
		public string TimeTaken { get; set; }
		[XmlElement("authtimetaken")]
		public string AuthTimeTaken { get; set; }
		[XmlElement("url")]
		public string Url { get; set; }
		[XmlAttribute("timestamp")]
		public string TimeStamp { get; set; }
		[XmlElement("threedsecure")]
		public ThreeDSecure ThreeDSecure { get; set; }
		[XmlElement("cvnresult")]
		public string CvnResult { get; set; }
		[XmlElement("avspostcoderesponse")]
		public string AvsPostcodeResponse { get; set; }
		[XmlElement("avsaddressresponse")]
		public string AvsAddressResponse { get; set; }
		[XmlElement("batchid")]
		public string BatchId { get; set; }
		[XmlElement("cardissuer")]
		public CardIssuer CardIssuer { get; set; }

        internal static RealExResponse Deserialize(string xml)
        {
            return new XmlSerializer(typeof(RealExResponse)).Deserialize(XDocument.Parse(xml).CreateReader()) as RealExResponse;
        }
	}
}