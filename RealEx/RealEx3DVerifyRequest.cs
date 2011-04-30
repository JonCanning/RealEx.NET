namespace RealEx
{
	public class RealEx3DVerifyRequest : RealExTransactionRequest
	{
		public RealEx3DVerifyRequest(string secret, string merchantId, string account, string orderId, Amount amount, Card card, string paRes)
			: base(secret, merchantId, account, orderId, amount, card)
		{
			PaRes = paRes;
			Type = "3ds-verifysig";
			IsSecure = true;
		}
		public string PaRes { get; set; }
	}
}