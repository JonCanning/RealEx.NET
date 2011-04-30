using System.Xml.Linq;

namespace RealEx.Serialization
{
    class CvnSerializer : ISerializer<Cvn>
    {
        public XElement Serialize(Cvn cvn)
        {
            return cvn == null ? null :
                                          new XElement("cvn",
                                                       cvn.ToXElement(x => x.Number),
                                                       cvn.ToXElement(x => (int)x.PresInd)
                                              );
        }
    }
}