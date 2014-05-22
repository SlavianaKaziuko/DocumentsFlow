using System;

namespace SOS.BusinessEntities
{
	public class CfsConsult
	{
		public int Id;
		public string Client;
		public int ClientId;
		public int Age;
		public string Specialist;
		public int LocalSpecialistId;
		public DateTime Date;
		public string Form;
		public int FormType;
		public string Content;
		public int ContentType;
		public string ProblemDiscription;
		public string ConversDiscription;
		public string ConversResults;
		public DateTime NextSessionDate;
	}
}
