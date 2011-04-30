namespace RealEx
{
	public abstract class RealExAdminRequest : RealExBaseRequest
	{
		internal RealExAdminRequest(string secret, string merchantId, string account, string orderId, string pasRef, string authCode)
			: base(secret, merchantId, account, orderId)
		{
			PasRef = pasRef;
			AuthCode = authCode;
		}
		public string PasRef { get; set; }
		public string AuthCode { get; set; }
	}
}