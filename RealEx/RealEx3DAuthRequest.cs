namespace RealEx
{
    public class RealEx3DAuthRequest : RealExAuthRequest
    {
        public RealEx3DAuthRequest(string secret, string merchantId, string account, string orderId, Amount amount, Card card, TssInfo tssInfo, ThreeDSecure threeDSecure, bool autoSettle, string custNum, string prodId, string varRef, Comments comments)
            : base(secret, merchantId, account, orderId, amount, card, tssInfo, autoSettle, custNum, prodId, varRef, comments)
        {
            Mpi = new Mpi(threeDSecure.Cavv, threeDSecure.Xid, threeDSecure.Eci);
        }
        public Mpi Mpi { get; private set; }
    }
}