using System.Text;
using System.Xml.Linq;

namespace RealEx.Serialization
{
    abstract class RealExBaseRequestSerializer : ISerializer<RealExBaseRequest>
    {
        public XElement Serialize(RealExBaseRequest realExBaseRequest)
        {
            return new XElement("request",
                                realExBaseRequest.ToXAttribute(x => x.Type),
                                realExBaseRequest.ToXAttribute(x => x.TimeStamp),
                                realExBaseRequest.ToXElement(x => x.MerchantId),
                                realExBaseRequest.ToXElement(x => x.Account),
                                realExBaseRequest.ToXElement(x => x.OrderId),
                                realExBaseRequest.ToXElement(x => x.Comments),
                                Sha1Element(realExBaseRequest)
                );
        }

        private static XElement Sha1Element(RealExBaseRequest realExBaseRequest)
        {
            return new XElement("sha1hash", GetSha1Hash(realExBaseRequest));
        }

        private static string GetSha1Hash(RealExBaseRequest realExBaseRequest)
        {
            var signature = new StringBuilder(realExBaseRequest.TimeStamp + "." + realExBaseRequest.MerchantId + "." + realExBaseRequest.OrderId + ".");
            if (realExBaseRequest.SignatureProperties != null)
            {
                foreach (var property in realExBaseRequest.SignatureProperties())
                {
                    signature.Append(property).Append(".");
                }
                signature.Remove(signature.Length - 1, 1);
            }
            else
            {
                signature.Append("..");
            }
            var signatureAndSecret = signature.ToString().ComputeHash() + "." + realExBaseRequest.Secret;
            return signatureAndSecret.ComputeHash();
        }
    }
}