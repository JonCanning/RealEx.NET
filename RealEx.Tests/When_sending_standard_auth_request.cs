using NUnit.Framework;

namespace RealEx.Tests
{
	public class When_sending_standard_auth_request : RealExBaseTest
	{
		[Test]
		public void Should_receive_success_response()
		{
			var response = GetStandardAuthResponse();
			Assert.AreEqual("00", response.Result);
		}
	}
}