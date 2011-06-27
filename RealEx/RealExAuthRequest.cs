namespace RealEx
{
    public class RealExAuthRequest : RealExTransactionRequest
    {
        public RealExAuthRequest(string secret, string merchantId, string account, string orderId, Amount amount, Card card, TssInfo tssInfo, bool autoSettle, string custNum, string prodId, string varRef, Comments comments)
            : base(secret, merchantId, account, orderId, amount, card, comments)
        {
            TssInfo = tssInfo;
            CustNum = custNum;
            ProdId = prodId;
            VarRef = varRef;
            Type = "auth";
            AutoSettle = new AutoSettle(autoSettle);
        }
        public string CustNum { get; private set; }
        public string ProdId { get; private set; }
        public string VarRef { get; private set; }
        public AutoSettle AutoSettle { get; private set; }
        public TssInfo TssInfo { get; private set; }
    }
}