using NUnit.Framework;

namespace RealEx.Tests
{
	[TestFixture]
	public class When_sending_settle_request : RealExBaseTest
	{
		[Test]
		public void Should_send_request_successfully()
		{
			var authResponse = GetStandardAuthResponse(false);
			var response = RealExRequestFactory.RealExSettleRequest(authResponse.OrderId, authResponse.PasRef, authResponse.AuthCode).GetResponse();
			Assert.AreEqual("00", response.Result);
		}
	}
}