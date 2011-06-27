namespace RealEx
{
    public abstract class RealExAdminRequest : RealExBaseRequest
    {
        internal RealExAdminRequest(string secret, string merchantId, string account, string orderId, string pasRef, string authCode, Comments comments)
            : base(secret, merchantId, account, orderId, comments)
        {
            PasRef = pasRef;
            AuthCode = authCode;
        }
        public string PasRef { get; private set; }
        public string AuthCode { get; private set; }
    }
}