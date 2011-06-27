namespace RealEx
{
	public class RealExTssRequest : RealExAuthRequest
	{
		public RealExTssRequest(string secret, string merchantId, string account, string orderId, Amount amount, Card card, TssInfo tssInfo, bool autoSettle, string custNum, string prodId, string varRef, Comments comments)
			: base(secret, merchantId, account, orderId, amount, card, tssInfo, autoSettle, custNum, prodId, varRef, comments)
		{
			Type = "tss";
		}
	}
}