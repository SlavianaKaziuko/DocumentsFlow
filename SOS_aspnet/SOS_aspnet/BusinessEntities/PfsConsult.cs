using System;

namespace SOS.BusinessEntities
{
	public class PfsConsult
	{
		public int Id;
		public int ClientId;
		public int Age;
		public string Client;
		public int LocalSpecialistId;
		public string Specialist;
		public DateTime Date;
		public bool StcGivingInformation;
		public bool StcConsultation;
		public bool StcPsychodiagnost;
		public bool StcTerrapevtSession;
		public string StcAnother;
		public bool StpScheduled;
		public string StpAnother;
		public int FormType;
		public string Form;
		public int ContentType;
		public string Content;
		public string ProblemDiscription;
		public string ConversDiscription;
		public string ConversResults;
		public DateTime NextSessionDate;
	}
}
