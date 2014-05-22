namespace SOS.BusinessEntities
{
	public class PfsJournal
	{
		public string Client;
		public int[] Counts;

		public PfsJournal(int size)
		{
			Counts = new int[size];
		}
	}
}
