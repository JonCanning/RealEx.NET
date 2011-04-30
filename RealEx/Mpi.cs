namespace RealEx
{
	public class Mpi
	{
		public Mpi(string cavv, string xid, string eci)
		{
			Cavv = cavv;
			Xid = xid;
			Eci = eci;
		}
		public string Eci { get; set; }
		public string Xid { get; set; }
		public string Cavv { get; set; }
	}
}