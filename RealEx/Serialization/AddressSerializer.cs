using System.Xml.Linq;

namespace RealEx.Serialization
{
    class AddressSerializer : ISerializer<Address>
    {
        public XElement Serialize(Address address)
        {
            if (address == null) return null;
            return new XElement("address",
                                address.ToXAttribute(x => x.Type),
                                address.ToXElement(x => x.Code),
                                address.ToXElement(x => x.Country)
                );
        }
    }
}