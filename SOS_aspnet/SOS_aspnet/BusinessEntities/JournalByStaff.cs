using System;

namespace SOS.BusinessEntities
{
    public class JournalByStaff
    {
        public string Relates { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string FarthersName { get; set; }
        public string Form { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}