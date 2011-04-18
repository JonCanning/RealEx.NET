using NUnit.Framework;

namespace RealEx.Tests
{
	[TestFixture]
	public class When_sending_rebate_request : RealExBaseTest
	{
		[Test]
		public void Should_receive_success_response()
		{
			var authResponse = GetStandardAuthResponse();
			var response = RealExRequestFactory.RealExRebateRequest(authResponse.OrderId, Amount, authResponse.PasRef, authResponse.AuthCode, "refund", true).GetResponse();
			Assert.AreEqual("00", response.Result);
		}
	}
}
