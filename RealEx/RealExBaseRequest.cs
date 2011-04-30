using System;
using System.Collections.Generic;

namespace RealEx
{
	public abstract class RealExBaseRequest
	{
		protected RealExBaseRequest(string secret, string merchantId, string account, string orderId)
		{
			TimeStamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
			OrderId = orderId;
			MerchantId = merchantId;
			Account = account;
			Secret = secret;
		}
		public string Type { get; set; }
		public string TimeStamp { get; set; }
		public string OrderId { get; set; }
		public string MerchantId { get; set; }
		public string Account { get; set; }
		public Comments Comments { get; set; }
		public string Sha1Hash { get; set; }
		internal Func<IEnumerable<string>> SignatureProperties { get; set; }
		public string Secret { get; set; }
		internal bool IsSecure { get; set; }
	}
}
