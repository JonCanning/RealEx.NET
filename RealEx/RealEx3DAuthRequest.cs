using System.Xml.Serialization;

namespace RealEx
{
	public class RealEx3DAuthRequest : RealExAuthRequest
	{
		internal RealEx3DAuthRequest() { }

		public RealEx3DAuthRequest(string secret, string merchantId, string account, string orderId, Amount amount, Card card, TssInfo tssInfo, ThreeDSecure threeDSecure, bool autoSettle)
			: base(secret, merchantId, account, orderId, amount, card, tssInfo, autoSettle)
		{
			Mpi = new Mpi(threeDSecure.Cavv, threeDSecure.Xid, threeDSecure.Eci);
		}
		[XmlElement("mpi")]
		public Mpi Mpi { get; set; }
	}
}