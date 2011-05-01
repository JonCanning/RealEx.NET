using System.Xml.Linq;

namespace RealEx.Serialization
{
    class RealExAuthRequestSerializer : RealExBaseRequestSerializer, ISerializer<RealExAuthRequest>
    {
        public XElement Serialize(RealExAuthRequest realExAuthRequest)
        {
            var xElement = base.Serialize(realExAuthRequest);
            xElement.Add(realExAuthRequest.ToXElement(x => x.Amount),
                         realExAuthRequest.ToXElement(x => x.Card),
                         realExAuthRequest.ToXElement(x => x.TssInfo),
                         realExAuthRequest.ToXElement(x => x.AutoSettle)
                         );
            return xElement;
        }
    }
}