using System.Xml.Linq;

namespace RealEx.Serialization
{
    class RealExTssRequestSerializer : RealExAuthRequestSerializer,ISerializer<RealExTssRequest>
    {
        public XElement Serialize(RealExTssRequest realExTssRequest)
        {
            return base.Serialize(realExTssRequest);
        }
    }
}