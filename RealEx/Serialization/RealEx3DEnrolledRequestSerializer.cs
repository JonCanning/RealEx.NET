using System.Xml.Linq;

namespace RealEx.Serialization
{
    class RealEx3DEnrolledRequestSerializer : RealExTransactionRequestSerializer, ISerializer<RealEx3DEnrolledRequest>
    {
        public XElement Serialize(RealEx3DEnrolledRequest realEx3DEnrolledRequest)
        {
            return base.Serialize(realEx3DEnrolledRequest);
        }
    }
}