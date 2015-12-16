using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityConsoleApp.Models;

namespace EntityConsoleApp
{
   public  class EntityTest
    {

       public static void CreateNewPatient() 
       {
           var dog = new AnimalType { TypeName= "Dog" };

           var patient = new Patient 
           {
               Name = "Willanson",
               BirthDate = new DateTime(2108, 1, 3),
               AnimalType = dog,
               Visits = new List<Visit> {
                new Visit{
                    Date = DateTime.Now
                }
                },
               FirstVisit = DateTime.Now
           };

           using (var context = new VetContext()) 
           {
               context.Patients.Add(patient);
               context.SaveChanges();
           }
       }

       public static void InsertDestination() 
       {
           var destination = new Destination 
           {
               Country = "Indonesia",
               Description = "EcoTourism at its best in exquisite Bali",
               Name = "Bali"
           };

           using (var context = new BreakAwayContext()) 
           {
               context.Destionations.Add(destination);
               context.SaveChanges();
           }
       }

       public static void InsertTrip() 
       {
           var trip = new Trip() 
           {
               CostUSD = 800,
               StartDate = new DateTime(2011,9,11),
               EndDate = new DateTime(2011, 9, 21),
           };

           using (var context = new BreakAwayContext()) 
           {
               context.Trips.Add(trip);
               context.SaveChanges();
           }
       }

       internal static void InsertPerson()
       {
           var person = new Person { 
           SocialSecurityNumber = 12345678,
           FirstName = "Rowan",
           LastName = "Miller"
           
           };

           using (var context = new BreakAwayContext()) 
           {
               context.Persons.Add(person);
               context.SaveChanges();
           }

       }

       public static void Initialize() 
       {
           Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BreakAwayContext>());   
       }
    }
}
