using System;
using NUnit.Framework;

namespace RealEx.Tests
{
	[TestFixture]
	public class When_sending_tss_request : RealExBaseTest
	{
		[Test]
		public void Should_receive_success_response()
		{
			var response = RealExRequestFactory.RealExTssRequest(Guid.NewGuid().ToString(), Amount, Card, true).GetResponse();
			Assert.AreEqual("00", response.Result);
		}
	}
}