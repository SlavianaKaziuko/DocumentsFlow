namespace SOS.BusinessEntities
{
	public class SpecJournal
	{
		public string Specialist;
		public int[] Counts;

		public SpecJournal(int size)
		{
			Counts = new int[size];
		}
	}
}
