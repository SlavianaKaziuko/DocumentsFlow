using System.Collections.Generic;

namespace SOS.BusinessEntities
{
	public class CfsJournal
	{
		public string Client;
		public int[] Counts;

		public CfsJournal(int size)
		{
			Counts = new int[size];
		}

	    public IEnumerator<CfsJournal> GetEnumerator()
	    {
	        throw new System.NotImplementedException();
	    }
	}
}
