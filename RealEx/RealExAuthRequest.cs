namespace RealEx
{
	public class RealExAuthRequest : RealExTransactionRequest
	{
		public RealExAuthRequest(string secret, string merchantId, string account, string orderId, Amount amount, Card card, TssInfo tssInfo, bool autoSettle)
			: base(secret, merchantId, account, orderId, amount, card)
		{
			TssInfo = tssInfo;
			Type = "auth";
			AutoSettle = new AutoSettle(autoSettle);
		}
		public string CustNum { get; set; }
		public string ProdId { get; set; }
		public string VarRef { get; set; }
		public AutoSettle AutoSettle { get; set; }
		public TssInfo TssInfo { get; set; }
	}
}