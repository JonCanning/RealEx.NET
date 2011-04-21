using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace RealEx
{
	internal class XmlSerializer
	{
		private static XDocument SerializeRequest(RealExBaseRequest realExBaseRequest)
		{
			realExBaseRequest.Sha1Hash = GetSha1Hash(realExBaseRequest);
			var xmlSerializer = new System.Xml.Serialization.XmlSerializer(realExBaseRequest.GetType());
			var memoryStream = new MemoryStream();
			xmlSerializer.Serialize(memoryStream, realExBaseRequest, new XmlSerializerNamespaces(new[] { new XmlQualifiedName() }));
			memoryStream.Position = 0;
			var xml = new StreamReader(memoryStream).ReadToEnd();
			return XDocument.Parse(xml);
		}

		internal static string Serialize(RealExBaseRequest realExBaseRequest)
		{
			var xDocument = SerializeRequest(realExBaseRequest);
			return xDocument.ToString();
		}

		internal static RealExResponse DeSerialize(string xml)
		{
			var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(RealExResponse));
			var memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(xml));
			return xmlSerializer.Deserialize(memoryStream) as RealExResponse;
		}

		private static string GetSha1Hash(RealExBaseRequest realExBaseRequest)
		{
			var signature = new StringBuilder(realExBaseRequest.TimeStamp + "." + realExBaseRequest.MerchantId + "." + realExBaseRequest.OrderId + ".");
			if (realExBaseRequest.SignatureProperties != null)
			{
				foreach (var property in realExBaseRequest.SignatureProperties())
				{
					signature.Append(property).Append(".");
				}
				signature.Remove(signature.Length - 1, 1);
			}
			else
			{
				signature.Append("..");
			}
			var signatureAndSecret = ComputeHash(signature.ToString()) + "." + realExBaseRequest.Secret;
			return ComputeHash(signatureAndSecret);
		}

		internal static string ComputeHash(string input)
		{
			return BitConverter.ToString(SHA1.Create().ComputeHash(Encoding.ASCII.GetBytes(input))).Replace("-", string.Empty).ToLower();
		}
	}

}