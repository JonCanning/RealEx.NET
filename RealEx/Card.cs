namespace RealEx
{
    public class Card
    {
        public Card(string chName, RealExCardType type, string number, string expDate, Cvn cvn, string issueNo = null)
        {
            ChName = chName;
            Type = type;
            Number = number;
            IssueNo = issueNo;
            Cvn = cvn;
            ExpDate = expDate;
        }
        public RealExCardType Type { get; private set; }
        public string Number { get; private set; }
        public string ExpDate { get; private set; }
        public string ChName { get; private set; }
        public string IssueNo { get; private set; }
        public Cvn Cvn { get; private set; }
    }
}