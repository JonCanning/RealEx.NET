using System.Xml.Linq;

namespace RealEx.Serialization
{
    class RealEx3DEnrolledRequestSerializer : ISerializer<RealEx3DEnrolledRequest>
    {
        private readonly ISerializer<RealExTransactionRequest> realExTransactionRequestSerializer;

        public RealEx3DEnrolledRequestSerializer(ISerializer<RealExTransactionRequest> realExTransactionRequestSerializer)
        {
            this.realExTransactionRequestSerializer = realExTransactionRequestSerializer;
        }

        public XElement Serialize(RealEx3DEnrolledRequest realEx3DEnrolledRequest)
        {
            return realExTransactionRequestSerializer.Serialize(realEx3DEnrolledRequest);
        }
    }
}