namespace RealEx
{
    public class Narrative
    {
        public Narrative(string chargeDescription)
        {
            ChargeDescription = chargeDescription;
        }

        public string ChargeDescription { get; private set; }
    }
}