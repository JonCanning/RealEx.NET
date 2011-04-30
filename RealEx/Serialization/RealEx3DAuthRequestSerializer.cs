using System.Xml.Linq;

namespace RealEx.Serialization
{
    class RealEx3DAuthRequestSerializer : ISerializer<RealEx3DAuthRequest>
    {
        private readonly ISerializer<RealExAuthRequest> realExAuthRequestSerializer;
        private readonly ISerializer<Mpi> mpiSerializer;

        public RealEx3DAuthRequestSerializer(ISerializer<RealExAuthRequest> realExAuthRequestSerializer, ISerializer<Mpi> mpiSerializer)
        {
            this.realExAuthRequestSerializer = realExAuthRequestSerializer;
            this.mpiSerializer = mpiSerializer;
        }

        public XElement Serialize(RealEx3DAuthRequest realExTransactionRequest)
        {
            var request = realExAuthRequestSerializer.Serialize(realExTransactionRequest);
            request.Add(mpiSerializer.Serialize(realExTransactionRequest.Mpi));
            return request;
        }
    }
}