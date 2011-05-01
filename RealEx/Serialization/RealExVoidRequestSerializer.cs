using System.Xml.Linq;

namespace RealEx.Serialization
{
    class RealExVoidRequestSerializer : RealExAdminRequestSerializer, ISerializer<RealExVoidRequest>
    {
        public XElement Serialize(RealExVoidRequest realExVoidRequest)
        {
            return base.Serialize(realExVoidRequest);
        }
    }
}