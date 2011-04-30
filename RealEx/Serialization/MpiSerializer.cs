using System.Xml.Linq;

namespace RealEx.Serialization
{
    class MpiSerializer : ISerializer<Mpi>
    {
        public XElement Serialize(Mpi mpi)
        {
            if (mpi == null) return null;
            return new XElement("mpi",
                                mpi.ToXElement(x => x.Cavv),
                                mpi.ToXElement(x => x.Eci),
                                mpi.ToXElement(x => x.Xid));
        }
    }
}