namespace RealEx
{
	public class RealExRequestFactory
	{
		private readonly string secret;
		private readonly string merchantId;
		private readonly string account;

		public RealExRequestFactory(string secret, string merchantId, string account = null)
		{
			this.secret = secret;
			this.merchantId = merchantId;
			this.account = account;
		}

		public RealExAuthRequest RealExAuthRequest(string orderId, Amount amount, Card card, TssInfo tssinfo, bool autoSettle)
		{
			return new RealExAuthRequest(secret, merchantId, account, orderId, amount, card, tssinfo, autoSettle);
		}

		public RealEx3DEnrolledRequest RealEx3DEnrolledRequest(string orderId, Amount amount, Card card)
		{
			return new RealEx3DEnrolledRequest(secret, merchantId, account, orderId, amount, card);
		}

		public RealEx3DVerifyRequest RealEx3DVerifyRequest(string orderId, Amount amount, Card card, string paRes)
		{
			return new RealEx3DVerifyRequest(secret, merchantId, account, orderId, amount, card, paRes);
		}

		public RealEx3DAuthRequest RealEx3DAuthRequest(string orderId, Amount amount, Card card, TssInfo tssInfo, ThreeDSecure threeDSecure)
		{
			return new RealEx3DAuthRequest(secret, merchantId, account, orderId, amount, card, tssInfo, threeDSecure, true);
		}

		public RealExRebateRequest RealExRebateRequest(string orderId, Amount amount, string pasRef, string authCode, string refundPassword, bool autosettle)
		{
			return new RealExRebateRequest(secret, merchantId, account, orderId, amount, pasRef, authCode, refundPassword, autosettle);
		}

		public RealExVoidRequest RealExVoidRequest(string orderId, string pasRef, string authCode)
		{
			return new RealExVoidRequest(secret, merchantId, account, orderId, pasRef, authCode);
		}

		public RealExTssRequest RealExTssRequest(string orderId, Amount amount, Card card, TssInfo tssinfo, bool autoSettle)
		{
			return new RealExTssRequest(secret, merchantId, account, orderId, amount, card, tssinfo, autoSettle);
		}

		public RealExSettleRequest RealExSettleRequest(string orderId, string pasRef, string authCode)
		{
			return new RealExSettleRequest(secret, merchantId, account, orderId, pasRef, authCode);
		}
	}
}