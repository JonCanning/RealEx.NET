using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace RealEx
{
    internal class XmlSerializer
    {
        private static XDocument SerializeRequest(RealExBaseRequest realExBaseRequest)
        {
            realExBaseRequest.Sha1Hash = GetSha1Hash(realExBaseRequest);
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(realExBaseRequest.GetType());
            var memoryStream = new MemoryStream();
            xmlSerializer.Serialize(memoryStream, realExBaseRequest, new XmlSerializerNamespaces(new[] { new XmlQualifiedName() }));
            memoryStream.Position = 0;
            var xml = new StreamReader(memoryStream).ReadToEnd();
            return XDocument.Parse(xml);
        }

        internal static string SerializeAuth(RealExAuthRequest realExAuthRequest)
        {
            var rootElement = RootElement(realExAuthRequest);
            rootElement.Add(AmountElement(realExAuthRequest.Amount),
                            CardElement(realExAuthRequest.Card),
                            TssInfoElement(realExAuthRequest.TssInfo),
                            CommentsElement(realExAuthRequest.Comments),
                            AutoSettleElement(realExAuthRequest.AutoSettle),
                            realExAuthRequest.ToXElement(x => x.Account),
                            realExAuthRequest.ToXElement(x => x.CustNum),
                            realExAuthRequest.ToXElement(x => x.MerchantId),
                            realExAuthRequest.ToXElement(x => x.OrderId),
                            realExAuthRequest.ToXElement(x => x.ProdId),
                            realExAuthRequest.ToXElement(x => x.VarRef)
                            );
            return rootElement.ToString();
        }

        private static XElement AutoSettleElement(AutoSettle autoSettle)
        {
            if (autoSettle == null) return null;
            return new XElement("autosettle",
                                autoSettle.ToXElement(x => x.Flag)
                                );
        }

        private static XElement CommentsElement(Comments comments)
        {
            if (comments == null) return null;
            return new XElement("comments",
                                comments.ToXElement(x => x.Comment1),
                                comments.ToXElement(x => x.Comment2)
                                );
        }

        private static XElement TssInfoElement(TssInfo tssInfo)
        {
            if (tssInfo == null) return null;
            return new XElement("tssinfo", 
                                AddressElement(tssInfo.BillingAddress),
                                AddressElement(tssInfo.ShippingAddress)
                                );
        }

        private static XElement AddressElement(Address address)
        {
            if (address == null) return null;
            return new XElement("address",
                                address.ToXAttribute(x => x.Type),
                                address.ToXElement(x => x.Code),
                                address.ToXElement(x => x.Country)
                                );
        }

        private static XElement CardElement(Card card)
        {
            if (card == null) return null;
            return new XElement("card",
                                card.ToXElement(x => x.ChName),
                                card.ToXElement(x => x.ExpDate),
                                card.ToXElement(x => x.IssueNo),
                                card.ToXElement(x => x.Number),
                                card.ToXElement(x => x.Type),
                                CvnElement(card.Cvn)
                                );
        }

        private static XElement CvnElement(Cvn cvn)
        {
            if (cvn == null) return null;
            return new XElement("cvn",
                                cvn.ToXElement(x => x.Number),
                                cvn.ToXElement(x => (int)x.PresInd)
                                );
        }

        private static XElement RootElement(RealExBaseRequest realExBaseRequest)
        {
            return new XElement("request",
                                realExBaseRequest.ToXAttribute(x => x.Type),
                                realExBaseRequest.ToXAttribute(x => x.TimeStamp),
                                realExBaseRequest.ToXElement(x => x.MerchantId),
                                realExBaseRequest.ToXElement(x => x.Account),
                                realExBaseRequest.ToXElement(x => x.OrderId),
                                Sha1Element(realExBaseRequest)
                                );
        }

        private static XElement AmountElement(Amount amount)
        {
            if (amount == null) return null;
            return new XElement("amount", 
                                amount.ToXAttribute(x => x.Currency), 
                                amount.ToXElement(x => x.Value)
                                );
        }

        private static XElement Sha1Element(RealExBaseRequest realExBaseRequest)
        {
            return new XElement("sha1hash",
                                GetSha1Hash(realExBaseRequest)
                                );
        }

        internal static string Serialize(RealExBaseRequest realExBaseRequest)
        {
            var xDocument = SerializeRequest(realExBaseRequest);
            return xDocument.ToString();
        }

        internal static RealExResponse DeSerialize(string xml)
        {
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(RealExResponse));
            var memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(xml));
            return xmlSerializer.Deserialize(memoryStream) as RealExResponse;
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
            var signatureAndSecret = ComputeHash(signature.ToString()) + "." + realExBaseRequest.Secret;
            return ComputeHash(signatureAndSecret);
        }

        internal static string ComputeHash(string input)
        {
            return BitConverter.ToString(SHA1.Create().ComputeHash(Encoding.ASCII.GetBytes(input))).Replace("-", string.Empty).ToLower();
        }
    }
}