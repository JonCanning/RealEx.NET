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
		private const string MerchantId = "merchantid";

		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			Amount = new Amount { Value = 100, Currency = RealExCurrency.EUR };
			Card = new Card { ChName = "C Holder", Number = "4012001037141112", Type = RealExCardType.VISA, Cvn = new Cvn { Number = "111" }, ExpDate = "1212" };
			RealExRequestFactory = new RealExRequestFactory(Secret, MerchantId);
		}

		protected RealExResponse GetStandardAuthResponse(bool autosettle = true)
		{
			var realExAuthRequest = RealExRequestFactory.RealExAuthRequest(Guid.NewGuid().ToString(), Amount, Card, new TssInfo(), autosettle);
			return realExAuthRequest.GetResponse();
		}
	}
}
