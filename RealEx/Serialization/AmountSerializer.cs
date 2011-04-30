using System.Xml.Linq;

namespace RealEx.Serialization
{
    class AmountSerializer : ISerializer<Amount>
    {
        public XElement Serialize(Amount amount)
        {
            if (amount == null) return null;
            return new XElement("amount",
                                amount.ToXAttribute(x => x.Currency),
                                amount.Value
                );
        }
    }
}