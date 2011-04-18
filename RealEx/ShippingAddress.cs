namespace RealEx
{
	public class ShippingAddress : Address
	{
		public ShippingAddress() { }

		public ShippingAddress(string address)
			: base("shipping", address)
		{
		}
	}
}