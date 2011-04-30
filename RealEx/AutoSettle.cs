namespace RealEx
{
	public class AutoSettle
	{
		public AutoSettle(bool flag)
		{
			Flag = flag ? "1" : "0";
		}
		public string Flag { get; set; }
	}
}