using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCsharpLearn.Models
{
    public class Patient
    {
        public Patient() 
        {
            Visits = new List<Visit>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public AnimalType AnimalType { get; set; }
        public DateTime FirstVisit { get; set; }
        public List<Visit> Visits { get; set; }
    }

    public class Visit 
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public String ReasonForVisit { get; set; }
        public String Outcome { get; set; }
        public Decimal Weight { get; set; }
        public int PatientId { get; set; }
    }

    public class AnimalType 
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
    }
}
