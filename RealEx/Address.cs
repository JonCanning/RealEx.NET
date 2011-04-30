namespace RealEx
{
	public abstract class Address
	{
		protected Address(string type)
		{
			Type = type;
		}
		public string Code { get; set; }
		public string Country { get; set; }
		public string Type { get; set; }
	}
}