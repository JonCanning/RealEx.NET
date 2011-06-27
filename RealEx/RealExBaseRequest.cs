using System;
using System.Collections.Generic;

namespace RealEx
{
    public abstract class RealExBaseRequest
    {
        protected RealExBaseRequest(string secret, string merchantId, string account, string orderId, Comments comments)
        {
            TimeStamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
            OrderId = orderId;
            MerchantId = merchantId;
            Account = account;
            Secret = secret;
        }
        public string Type { get; protected set; }
        public string TimeStamp { get; private set; }
        public string OrderId { get; private set; }
        public string MerchantId { get; private set; }
        public string Account { get; private set; }
        public Comments Comments { get; private set; }
        internal Func<IEnumerable<string>> SignatureProperties { get; set; }
        public string Secret { get; private set; }
        internal bool IsSecure { get; set; }
    }
}
