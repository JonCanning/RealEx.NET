using System.Xml.Linq;

namespace RealEx.Serialization
{
    class RealExAuthRequestSerializer : ISerializer<RealExAuthRequest>
    {
        private readonly ISerializer<RealExBaseRequest> realExBaseRequestSerializer;
        private readonly ISerializer<Amount> amountSerializer;
        private readonly ISerializer<Card> cardSerializer;
        private readonly ISerializer<TssInfo> tssInfoSerializer;
        private readonly ISerializer<Comments> commentsSerializer;
        private readonly ISerializer<AutoSettle> autoSettleSerializer;

        public RealExAuthRequestSerializer(ISerializer<RealExBaseRequest> realExBaseRequestSerializer, ISerializer<Amount> amountSerializer, ISerializer<Card> cardSerializer, ISerializer<TssInfo> tssInfoSerializer, ISerializer<Comments> commentsSerializer, ISerializer<AutoSettle> autoSettleSerializer)
        {
            this.realExBaseRequestSerializer = realExBaseRequestSerializer;
            this.amountSerializer = amountSerializer;
            this.cardSerializer = cardSerializer;
            this.tssInfoSerializer = tssInfoSerializer;
            this.commentsSerializer = commentsSerializer;
            this.autoSettleSerializer = autoSettleSerializer;
        }

        public XElement Serialize(RealExAuthRequest realExAuthRequest)
        {
            var request = realExBaseRequestSerializer.Serialize(realExAuthRequest);
            request.Add(amountSerializer.Serialize(realExAuthRequest.Amount),
                        cardSerializer.Serialize(realExAuthRequest.Card),
                        tssInfoSerializer.Serialize(realExAuthRequest.TssInfo),
                        commentsSerializer.Serialize(realExAuthRequest.Comments),
                        autoSettleSerializer.Serialize(realExAuthRequest.AutoSettle)
                        );
            return request;
        }
    }
}