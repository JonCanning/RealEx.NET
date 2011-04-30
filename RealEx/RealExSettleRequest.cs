namespace RealEx
{
	public class RealExSettleRequest : RealExAdminRequest
	{
		public RealExSettleRequest(string secret, string merchantId, string account, string orderId, string pasRef, string authCode)
			: base(secret, merchantId, account, orderId, pasRef, authCode)
		{
			Type = "settle";
		}
	}
}