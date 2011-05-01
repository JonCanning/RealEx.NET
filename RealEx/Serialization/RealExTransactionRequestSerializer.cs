using System.Xml.Linq;

namespace RealEx.Serialization
{
    abstract class RealExTransactionRequestSerializer : RealExBaseRequestSerializer, ISerializer<RealExTransactionRequest>
    {
        public XElement Serialize(RealExTransactionRequest realExTransactionRequest)
        {
            var xElement = base.Serialize(realExTransactionRequest);
            xElement.Add(realExTransactionRequest.ToXElement(x => x.Amount),
                         realExTransactionRequest.ToXElement(x => x.Card)
                         );
            return xElement;
        }
    }
}