using System;
using System.Web;
using HtmlAgilityPack;
using NUnit.Framework;

namespace RealEx.Tests
{
	public class When_sending_3d_auth_request : RealExBaseTest
	{
		[Test]
		public void Should_send_3d_auth_request_successfully()
		{
			var orderId = Guid.NewGuid().ToString();
			var response = RealExRequestFactory.RealEx3DEnrolledRequest(orderId, Amount, Card).GetResponse();
			Assert.AreEqual("00", response.Result);
			var formReponse = FormPoster.Post(new Uri(response.Url), string.Format("&PaReq={0}&MD={1}&TermUrl={2}", HttpUtility.UrlEncode(response.PaReq), HttpUtility.UrlEncode("merchant data"), HttpUtility.UrlEncode("http://myurl.com")));
			var htmlDocument = new HtmlDocument();
			htmlDocument.LoadHtml(formReponse);
			var paRes = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='PaRes']").GetAttributeValue("value", "");
			response = RealExRequestFactory.RealEx3DVerifyRequest(orderId, Amount, Card, paRes).GetResponse();
			Assert.AreEqual("00", response.Result);
			response = RealExRequestFactory.RealEx3DAuthRequest(orderId, Amount, Card, new TssInfo(), response.ThreeDSecure).GetResponse();
			Assert.AreEqual("00", response.Result);
		}
	}
}