using System.Collections.Generic;

namespace RealEx.Serialization
{
    class Serializer
    {
        private readonly KeyedByTypeCollection<ISerializer> serializers = new KeyedByTypeCollection<ISerializer>();

        internal Serializer()
        {
            serializers.Add(new CvnSerializer());
            serializers.Add(new CardSerializer(serializers.Find<ISerializer<Cvn>>()));
            serializers.Add(new AmountSerializer());
            serializers.Add(new AddressSerializer());
            serializers.Add(new TssInfoSerializer(serializers.Find<ISerializer<Address>>()));
            serializers.Add(new CommentsSerializer());
            serializers.Add(new AutoSettleSerializer());
            serializers.Add(new RealExBaseRequestSerializer());
            serializers.Add(new RealExAuthRequestSerializer(serializers.Find<ISerializer<RealExBaseRequest>>(),
                                                            serializers.Find<ISerializer<Amount>>(),
                                                            serializers.Find<ISerializer<Card>>(),
                                                            serializers.Find<ISerializer<TssInfo>>(),
                                                            serializers.Find<ISerializer<Comments>>(),
                                                            serializers.Find<ISerializer<AutoSettle>>()
                                                            ));
            serializers.Add(new RealExTransactionRequestSerializer(serializers.Find<ISerializer<RealExBaseRequest>>(),
                                                                    serializers.Find<ISerializer<Amount>>(),
                                                                    serializers.Find<ISerializer<Card>>()
                                                                    ));
            serializers.Add(new RealEx3DEnrolledRequestSerializer(serializers.Find<RealExTransactionRequestSerializer>()));
        }

        internal string Serialize<T>(T source) where T : class
        {
            var serializer = serializers.Find<ISerializer<T>>();
            return serializer.Serialize(source).ToString();
        }
    }
}