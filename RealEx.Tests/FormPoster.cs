using System;
using System.IO;
using System.Net;
using System.Text;

namespace RealEx.Tests
{
	public class FormPoster
	{
		public static string Post(Uri url, string formData)
		{
			var webRequest = (HttpWebRequest)WebRequest.Create(url);
			webRequest.Method = WebRequestMethods.Http.Post;
			webRequest.ContentType = "application/x-www-form-urlencoded";
			var requestStream = webRequest.GetRequestStream();
			var bytes = Encoding.Default.GetBytes(formData);
			requestStream.Write(bytes, 0, bytes.Length);
			requestStream.Close();
			var webResponse = webRequest.GetResponse();
			return new StreamReader(webResponse.GetResponseStream()).ReadToEnd();
		}
	}
}
