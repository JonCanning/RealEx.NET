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

        public RealExAuthRequest RealExAuthRequest(string orderId, Amount amount, Card card, bool autoSettle, TssInfo tssinfo = null, string custNum = null, string prodId = null, string varRef = null, Comments comments = null)
        {
            return new RealExAuthRequest(secret, merchantId, account, orderId, amount, card, tssinfo, autoSettle, custNum, prodId, varRef, comments);
        }

        public RealEx3DEnrolledRequest RealEx3DEnrolledRequest(string orderId, Amount amount, Card card, Comments comments = null)
        {
            return new RealEx3DEnrolledRequest(secret, merchantId, account, orderId, amount, card, comments);
        }

        public RealEx3DVerifyRequest RealEx3DVerifyRequest(string orderId, Amount amount, Card card, string paRes, Comments comments = null)
        {
            return new RealEx3DVerifyRequest(secret, merchantId, account, orderId, amount, card, paRes, comments);
        }

        public RealEx3DAuthRequest RealEx3DAuthRequest(string orderId, Amount amount, Card card, ThreeDSecure threeDSecure, TssInfo tssInfo = null, string custNum = null, string prodId = null, string varRef = null, Comments comments = null)
        {
            return new RealEx3DAuthRequest(secret, merchantId, account, orderId, amount, card, tssInfo, threeDSecure, true, custNum, prodId, varRef, comments);
        }

        public RealExRebateRequest RealExRebateRequest(string orderId, Amount amount, string pasRef, string authCode, string refundPassword, bool autosettle, Comments comments = null)
        {
            return new RealExRebateRequest(secret, merchantId, account, orderId, amount, pasRef, authCode, refundPassword, autosettle, comments);
        }

        public RealExVoidRequest RealExVoidRequest(string orderId, string pasRef, string authCode, Comments comments = null)
        {
            return new RealExVoidRequest(secret, merchantId, account, orderId, pasRef, authCode, comments);
        }

        public RealExTssRequest RealExTssRequest(string orderId, Amount amount, Card card, bool autoSettle, TssInfo tssinfo = null, string custNum = null, string prodId = null, string varRef = null, Comments comments = null)
        {
            return new RealExTssRequest(secret, merchantId, account, orderId, amount, card, tssinfo, autoSettle, custNum, prodId, varRef, comments);
        }

        public RealExSettleRequest RealExSettleRequest(string orderId, string pasRef, string authCode, Comments comments = null)
        {
            return new RealExSettleRequest(secret, merchantId, account, orderId, pasRef, authCode, comments);
        }
    }
}