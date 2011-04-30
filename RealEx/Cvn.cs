using System;
using System.ComponentModel;

namespace RealEx
{
	public class Cvn
	{
	    public Cvn(string number)
	    {
	        Number = number;
	        if (number.Length != 3)
	        {
	            throw new ArgumentException("Cvn number must be 3 digits");
	        }
            PresInd = PresInd.CvnPresent;
	    }

        public Cvn(PresInd presInd)
        {
            if (presInd == PresInd.CvnPresent)
            {
                throw new InvalidEnumArgumentException("Cannot set PresInd to Cvn Present without a Cvn");
            }
            PresInd = presInd;
        }

	    public string Number { get; set; }
		public PresInd PresInd { get; set; }
	}
}