namespace RealEx
{
    public class TssInfo
    {
        public string CustNum { get; set; }
        public string ProdId { get; set; }
        public string VarRef { get; set; }
        public string CustIpAddress { get; set; }
        public BillingAddress BillingAddress { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
    }
}