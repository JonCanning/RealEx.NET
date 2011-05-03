using System.IO;
using System.Net;
using System.Text;
using RealEx.Serialization;

namespace RealEx
{
	public static class RealExSender
	{
		private const string RequestUrl = "https://epage.payandshop.com/epage-remote.cgi";
		private const string SecureRequestUrl = "https://epage.payandshop.com/epage-3dsecure.cgi";

		public static RealExResponse GetResponse<T>(this T realExRequest) where T : RealExBaseRequest
		{
			var url = realExRequest.IsSecure ? SecureRequestUrl : RequestUrl;
			var xml = Serializer.For<T>().Serialize(realExRequest).ToString().ConvertTo7BitEncoding();
			var xmlBytes = Encoding.ASCII.GetBytes(xml);
			var webRequest = (HttpWebRequest)WebRequest.Create(url);
			webRequest.Method = WebRequestMethods.Http.Post;
			var requestStream = webRequest.GetRequestStream();
			requestStream.Write(xmlBytes, 0, xmlBytes.Length);
			requestStream.Close();
			var response = webRequest.GetResponse();
			var stringResponse = new StreamReader(response.GetResponseStream()).ReadToEnd();
			return RealExResponse.DeSerialize(stringResponse);
		}
	}
}