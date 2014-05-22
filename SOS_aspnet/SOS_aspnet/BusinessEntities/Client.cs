using System;

namespace SOS.BusinessEntities
{
	public class Client
	{
		public int Id { get; set; }
		public string Surname { get; set; }
		public string Name { get; set; }
		public string FathersName { get; set; }
		public string Sex { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Type { get; set; }
        public string FIO { get; set; }

		public Client(string type)
		{
			Type = type;
		}
	}
}
