using System.Xml.Linq;

namespace RealEx.Serialization
{
    class NarrativeSerializer : ISerializer<Narrative>
    {
        public XElement Serialize(Narrative narrative)
        {
            return new XElement("narrative", narrative.ToXElement(x => x.ChargeDescription));
        }
    }
}