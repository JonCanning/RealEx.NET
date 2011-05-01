namespace RealEx
{
	public class RealExRebateRequest : RealExAdminRequest
	{
		public RealExRebateRequest(string secret, string merchantId, string account, string orderId, Amount amount, string pasRef, string authCode, string refundPassword, bool autoSettle = false)
			: base(secret, merchantId, account, orderId, pasRef, authCode)
		{
			SignatureProperties = () => new[] { Amount.Value.ToString(), Amount.Currency.CurrencyName() + "." };
			Type = "rebate";
			AutoSettle = new AutoSettle(autoSettle);
			RefundHash = refundPassword.ComputeHash();
			Amount = amount;
		}
		public string RefundHash { get; set; }
		public AutoSettle AutoSettle { get; set; }
		public Amount Amount { get; set; }
	}
}
