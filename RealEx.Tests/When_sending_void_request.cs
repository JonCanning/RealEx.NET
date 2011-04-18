using NUnit.Framework;

namespace RealEx.Tests
{
	[TestFixture]
	public class When_sending_void_request : RealExBaseTest
	{
		[Test]
		public void Should_send_request_successfully()
		{
			var authResponse = GetStandardAuthResponse();
			var response = RealExRequestFactory.RealExVoidRequest(authResponse.OrderId, authResponse.PasRef, authResponse.AuthCode).GetResponse();
			Assert.AreEqual("00", response.Result);
		}
	}
}