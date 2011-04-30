using System.Xml.Linq;

namespace RealEx.Serialization
{
    class TssInfoSerializer : ISerializer<TssInfo>
    {
        private readonly ISerializer<Address> addressSerializer;

        public TssInfoSerializer(ISerializer<Address> addressSerializer)
        {
            this.addressSerializer = addressSerializer;
        }

        public XElement Serialize(TssInfo tssInfo)
        {
            if (tssInfo == null) return null;
            return new XElement("tssinfo",
                                addressSerializer.Serialize(tssInfo.BillingAddress),
                                addressSerializer.Serialize(tssInfo.ShippingAddress)
                );
        }
    }
}