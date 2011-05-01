using System.Xml.Linq;

namespace RealEx.Serialization
{
    class RealEx3DAuthRequestSerializer : RealExAuthRequestSerializer, ISerializer<RealEx3DAuthRequest>
    {
         public XElement Serialize(RealEx3DAuthRequest realEx3DAuthRequest)
        {
            var xElement = base.Serialize(realEx3DAuthRequest);
            xElement.Add(realEx3DAuthRequest.ToXElement(x => x.Mpi));
            return xElement;
        }
    }
}