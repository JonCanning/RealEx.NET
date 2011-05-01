using System.Xml.Linq;

namespace RealEx.Serialization
{
    class CardSerializer : ISerializer<Card>
    {
        public XElement Serialize(Card card)
        {
            return card == null ? null : new XElement("card",
                                                      card.ToXElement(x => x.ChName),
                                                      card.ToXElement(x => x.ExpDate),
                                                      card.ToXElement(x => x.IssueNo),
                                                      card.ToXElement(x => x.Number),
                                                      card.ToXElement(x => x.Type),
                                                      card.ToXElement(x => x.Cvn)
                                                      );
        }
    }
}