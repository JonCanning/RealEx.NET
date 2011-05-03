using System;
using System.Security.Cryptography;
using System.Text;

namespace RealEx
{
    internal static class ExtensionMethods
    {
        internal static string CurrencyName(this RealExCurrency realExCurrency)
        {
            return Enum.GetName(typeof(RealExCurrency), realExCurrency);
        }

        internal static string ComputeHash(this string input)
        {
            return BitConverter.ToString(SHA1.Create().ComputeHash(Encoding.ASCII.GetBytes(input))).Replace("-", string.Empty).ToLower();
        }

        internal static string ConvertTo7BitEncoding(this string input)
		{
			var dstEncoding = Encoding.GetEncoding(20105);
			return dstEncoding.GetString(Encoding.Convert(Encoding.Unicode, dstEncoding, Encoding.Unicode.GetBytes(input)));
		}
    }
}