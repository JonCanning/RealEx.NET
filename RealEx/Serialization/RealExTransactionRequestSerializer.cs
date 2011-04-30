using System.Xml.Linq;

namespace RealEx.Serialization
{
    class RealExTransactionRequestSerializer : ISerializer<RealExTransactionRequest>
    {
        private readonly ISerializer<RealExBaseRequest> realExBaseRequestSerializer;
        private readonly ISerializer<Amount> amountSerializer;
        private readonly ISerializer<Card> cardSerializer;

        public RealExTransactionRequestSerializer(ISerializer<RealExBaseRequest> realExBaseRequestSerializer, ISerializer<Amount> amountSerializer, ISerializer<Card> cardSerializer)
        {
            this.realExBaseRequestSerializer = realExBaseRequestSerializer;
            this.amountSerializer = amountSerializer;
            this.cardSerializer = cardSerializer;
        }

        public XElement Serialize(RealExTransactionRequest realExTransactionRequest)
        {
            var request = realExBaseRequestSerializer.Serialize(realExTransactionRequest);
            request.Add(amountSerializer.Serialize(realExTransactionRequest.Amount),
                        cardSerializer.Serialize(realExTransactionRequest.Card)
                        );
            return request;
        }
    }
}