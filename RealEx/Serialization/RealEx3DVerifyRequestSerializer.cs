using System.Xml.Linq;

namespace RealEx.Serialization
{
    class RealEx3DVerifyRequestSerializer : RealExTransactionRequestSerializer, ISerializer<RealEx3DVerifyRequest>
    {
        public XElement Serialize(RealEx3DVerifyRequest realEx3DVerifyRequest)
        {
            var xElement = base.Serialize(realEx3DVerifyRequest);
            xElement.Add(realEx3DVerifyRequest.ToXElement(x => x.PaRes));
            return xElement;
        }
    }
}