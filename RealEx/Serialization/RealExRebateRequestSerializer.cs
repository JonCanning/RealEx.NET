using System.Xml.Linq;

namespace RealEx.Serialization
{
    class RealExRebateRequestSerializer : RealExAdminRequestSerializer, ISerializer<RealExRebateRequest>
    {
        public XElement Serialize(RealExRebateRequest realExRebateRequest)
        {
            var xElement = base.Serialize(realExRebateRequest);
            xElement.Add(realExRebateRequest.ToXElement(x => x.RefundHash),
                         realExRebateRequest.ToXElement(x => x.AutoSettle),
                         realExRebateRequest.ToXElement(x => x.Amount)
                         );
            return xElement;
        }
    }
}