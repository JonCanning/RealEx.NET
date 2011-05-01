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
    }
}