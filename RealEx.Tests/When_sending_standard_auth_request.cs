using NUnit.Framework;

namespace RealEx.Tests
{
	public class When_sending_standard_auth_request : RealExBaseTest
	{
		[Test]
		public void Should_send_request_successfully()
		{
			var response = GetStandardAuthResponse();
			Assert.AreEqual("00", response.Result);
		}
	}
}