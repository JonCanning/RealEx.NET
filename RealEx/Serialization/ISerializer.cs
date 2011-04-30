using System.Xml.Linq;

namespace RealEx.Serialization
{
    interface ISerializer<T> : ISerializer where T : class
    {
        XElement Serialize(T realExTransactionRequest);
    }

    interface ISerializer { }
}