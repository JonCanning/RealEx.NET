using System.Xml.Linq;

namespace RealEx.Serialization
{
    class CardSerializer : ISerializer<Card>
    {
        private readonly ISerializer<Cvn> cvnSerializer;

        public CardSerializer(ISerializer<Cvn> cvnSerializer)
        {
            this.cvnSerializer = cvnSerializer;
        }

        public XElement Serialize(Card realExAuthRequest)
        {
            return realExAuthRequest == null ? null :
                                                        new XElement("card",
                                                                     realExAuthRequest.ToXElement(x => x.ChName),
                                                                     realExAuthRequest.ToXElement(x => x.ExpDate),
                                                                     realExAuthRequest.ToXElement(x => x.IssueNo),
                                                                     realExAuthRequest.ToXElement(x => x.Number),
                                                                     realExAuthRequest.ToXElement(x => x.Type),
                                                                     cvnSerializer.Serialize(realExAuthRequest.Cvn)
                                                            );
        }
    }
}