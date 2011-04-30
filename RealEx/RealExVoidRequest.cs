namespace RealEx
{
	public class RealExVoidRequest : RealExAdminRequest
	{
		public RealExVoidRequest(string secret, string merchantId, string account, string orderId, string pasRef, string authCode)
			: base(secret, merchantId, account, orderId, pasRef, authCode)
		{
			Type = "void";
		}
	}
}
