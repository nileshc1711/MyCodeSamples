using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityConsoleApp.Models;

namespace EntityConsoleApp
{
    public class EntityTest
    {

        public static void CreateNewPatient()
        {
            var dog = new AnimalType { TypeName = "Dog" };

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
                StartDate = new DateTime(2011, 9, 11),
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
            var person = new Person
            {
                SocialSecurityNumber = 12345677,
                FirstName = "William",
                LastName = "Keen"

            };

            using (var context = new BreakAwayContext())
            {
                context.Persons.Add(person);
                context.SaveChanges();
            }

        }

        internal static void UpdateTrip()
        {
            using (var context = new BreakAwayContext())
            {
                var trip = context.Trips.FirstOrDefault();
                trip.CostUSD = 750;
                context.SaveChanges();
            }
        }

        internal static void UpdatePerson()
        {
            using (var context = new BreakAwayContext())
            {
                var person = context.Persons.FirstOrDefault();
                person.FirstName = "Rowena";
                context.SaveChanges();
            }
        }

        public static void Initialize()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BreakAwayContext>());
        }

        public static void DeleteDestinationInMemoryAndDbCascade()
        {
            int destionationId;
            using (var context = new BreakAwayContext())
            {
                var destionation = new Destination
                {
                    Name = "Sample Destionation",
                    Lodgings = new List<Lodging> {
                   new Lodging{ Name= "Lodging One" },
                   new Lodging{ Name= "Lodging One" },
                   }
                };

                context.Destionations.Add(destionation);
                context.SaveChanges();
                destionationId = destionation.DestinationId;
            }

            using (var context = new BreakAwayContext())
            {
                var destination = context.Destionations.SingleOrDefault(x => x.DestinationId == destionationId);
                //var destinationWithLodging  = context.Destionations.Include(x => x.Lodgings).SingleOrDefault(x => x.DestinationId == destionationId);

                //var aLodgings = destination.Lodgings.FirstOrDefault();
                //var bLodgings = destinationWithLodging.Lodgings.FirstOrDefault();

                context.Destionations.Remove(destination);
                //Console.WriteLine("State of One Lodging: {0}",
                //  context.Entry<Lodging>(aLodgings).State.ToString());

                context.SaveChanges();

            }

            using (var context = new BreakAwayContext())
            {
                var lodgings = context.Lodgings
                        .Where(l => l.DestinationId == destionationId).ToList();
               
                Console.WriteLine("Lodgings: {0}", lodgings.Count);
            }
        }
    }
}
