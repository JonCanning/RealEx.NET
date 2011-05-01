using System.Xml.Linq;

namespace RealEx.Serialization
{
    class RealExSettleRequestSerializer : RealExAdminRequestSerializer, ISerializer<RealExSettleRequest>
    {
        public XElement Serialize(RealExSettleRequest source)
        {
            return base.Serialize(source);
        }
    }
}