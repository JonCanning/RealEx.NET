namespace RealEx
{
    public class RealEx3DVerifyRequest : RealExTransactionRequest
    {
        public RealEx3DVerifyRequest(string secret, string merchantId, string account, string orderId, Amount amount, Card card, string paRes, Comments comments)
            : base(secret, merchantId, account, orderId, amount, card, comments)
        {
            PaRes = paRes;
            Type = "3ds-verifysig";
            IsSecure = true;
        }
        public string PaRes { get; private set; }
    }
}