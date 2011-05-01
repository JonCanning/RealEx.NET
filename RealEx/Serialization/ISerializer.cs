using System.Xml.Linq;

namespace RealEx.Serialization
{
    interface ISerializer<T> : ISerializer
    {
        XElement Serialize(T source);
    }

    interface ISerializer { }
}