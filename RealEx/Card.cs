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
		public RealExCardType Type { get; set; }
		public string Number { get; set; }
		public string ExpDate { get; set; }
		public string ChName { get; set; }
		public string IssueNo { get; set; }
		public Cvn Cvn { get; set; }
	}
}