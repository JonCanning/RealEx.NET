using System.Xml.Linq;

namespace RealEx.Serialization
{
    class AutoSettleSerializer : ISerializer<AutoSettle>
    {
        public XElement Serialize(AutoSettle autoSettle)
        {
            if (autoSettle == null) return null;
            return new XElement("autosettle",
                                autoSettle.ToXAttribute(x => x.Flag)
                );
        }
    }
}