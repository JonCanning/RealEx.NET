using System;
using NUnit.Framework;

namespace RealEx.Tests
{
    public class RealExBaseTest
    {
        protected Amount Amount;
        protected Card Card;
        protected RealExRequestFactory RealExRequestFactory;
        private const string Secret = "secret";
        private const string MerchantId = "merchantId";

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            Amount = new Amount(100, RealExCurrency.EUR);
            Card = new Card ("C Holder", RealExCardType.VISA,  "4012001037141112", "1212", new Cvn("123"));
            RealExRequestFactory = new RealExRequestFactory(Secret, MerchantId);
        }

        protected RealExResponse GetStandardAuthResponse(bool autosettle = true)
        {
            var realExAuthRequest = RealExRequestFactory.RealExAuthRequest(Guid.NewGuid().ToString(), Amount, Card, autosettle);
            return realExAuthRequest.GetResponse();
        }
    }
}
