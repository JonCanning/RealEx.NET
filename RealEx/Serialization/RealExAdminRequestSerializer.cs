using System.Xml.Linq;

namespace RealEx.Serialization
{
    abstract class RealExAdminRequestSerializer : RealExBaseRequestSerializer, ISerializer<RealExAdminRequest>
    {
        public XElement Serialize(RealExAdminRequest realExAdminRequest)
        {
            var xElement = base.Serialize(realExAdminRequest);
            xElement.Add(realExAdminRequest.ToXElement(x => x.PasRef),
                         realExAdminRequest.ToXElement(x => x.AuthCode));
            return xElement;
        }
    }
}