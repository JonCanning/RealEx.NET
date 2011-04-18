using System;

namespace RealEx
{
	internal static class ExtensionMethods
	{
		internal static string CurrencyName(this RealExCurrency realExCurrency)
		{
			return Enum.GetName(typeof(RealExCurrency), realExCurrency);
		}
	}
}