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

    #region BreakAwayContext Entities
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
        public Person PrimaryContact { get; set; }
        public Person SecondaryContact { get; set; }
        public string Owner { get; set; }
        public bool IsResort { get; set; }
        public decimal MilesFromNearestAirport { get; set; }
        public int DestinationId { get; set; }

        public Destination Destination { get; set; }
        public List<InternetSpecial> InternetSpecials { get; set; }
    }

    public class InternetSpecial {
        public int InternetSpecialId { get; set; }
        public int Nights { get; set; }
        public decimal CostUSD { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public int AccomodationId { get; set; }

        public Lodging Accomodation { get; set; }
    
    }

    public class Trip
    {
        //[Key] ==> Eqivalent added in configuration cs file
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Identifier { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Decimal CostUSD { get; set; }

        [Timestamp]
        public byte[] Rowversion { get; set; }

    }

    public class Person
    {
        /// <summary>
        ///  instantiate a new Address which is complex type
        ///  and would give DbUpdateException if not instantiated.
        /// </summary>
        public Person()
        {
            Address = new Address();
            Info = new PersonalInfo { 
            Height = new Measurement(),
            Weight = new Measurement()
            };
        }
        public int PersonId { get; set; }
        //[ConcurrencyCheck] Configured in configuration file
        public int SocialSecurityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PersonalInfo Info { get; set; }
        public Address Address { get; set; }

        public List<Lodging> PrimaryContactFor { get; set; }
        public List<Lodging> SecondaryContactFor { get; set; }
    }

    #region Complex Type -Example
    /// <summary>
    /// Complex Type does not have a key Property
    /// 1. Complex types have no key property.
    ///2. Complex types can only contain primitive properties.
    ///3. When used as a property in another class, the property must represent a single
    ///instance. It cannot be a collection type.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Id is not required by convention, but we can configure it to have ID field check modelBuilder in OnModelCreating
        /// </summary>
        public int AddressId { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

    }
    /// <summary>
    /// Complex and Nested Complex Types
    /// (Non-Primitive)
    /// </summary>
    public class PersonalInfo
    {
        public Measurement Weight { get; set; }
        public Measurement Height { get; set; }
        public string DietryRestrictions { get; set; }
    }
    public class Measurement
    {
        public decimal Reading { get; set; }
        public string Units { get; set; }
    }
    #endregion
    #endregion
}
