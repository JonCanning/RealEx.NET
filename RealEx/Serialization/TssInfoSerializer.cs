using System.Xml.Linq;

namespace RealEx.Serialization
{
    class TssInfoSerializer : ISerializer<TssInfo>
    {
        public XElement Serialize(TssInfo tssInfo)
        {
            if (tssInfo == null) return null;
            return new XElement("tssinfo",
                                tssInfo.ToXElement(x => x.BillingAddress),
                                tssInfo.ToXElement(x => x.ShippingAddress),
                                tssInfo.ToXElement(x => x.CustIpAddress),
                                tssInfo.ToXElement(x => x.CustNum),
                                tssInfo.ToXElement(x => x.Narrative),
                                tssInfo.ToXElement(x => x.ProdId),
                                tssInfo.ToXElement(x => x.VarRef)
                                );
        }
    }
}