using System.Xml.Linq;

namespace RealEx.Serialization
{
    class CommentsSerializer : ISerializer<Comments>
    {
        public XElement Serialize(Comments comments)
        {
            if (comments == null) return null;
            return new XElement("comments",
                                comments.ToXElement(x => x.Comment1),
                                comments.ToXElement(x => x.Comment2)
                                );
        }
    }
}