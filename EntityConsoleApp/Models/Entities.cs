using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityConsoleApp.Models
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

    public class Destination 
    {
        
        public int DestinationId { get; set; }
        
        public string Name { get; set; }
        public string Country { get; set; }
        
        public string Description { get; set; }
        
        public byte[] Photo { get; set; }

        public List<Lodging> Lodgings { get; set; } 
    }

    public class Lodging 
    {
        public int LodgingId { get; set; }
        [MinLength(10)]
        public string Name { get; set; }
        public string Owner { get; set; }
        public bool IsResort { get; set; }

        public Destination Destination { get; set; }  
    }
}
