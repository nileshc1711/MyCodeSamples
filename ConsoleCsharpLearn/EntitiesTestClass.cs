using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCsharpLearn.Models;

namespace ConsoleCsharpLearn
{
    class EntitiesTestClass
    {
        //ObjectSet<> is basis for ur queries whether u require an entire EntitySet of People Entity or you request a subset of it.
        // Each EntityClass in Class Diagram you can see that it inherits from d the EntityObject class and has including properties based on the model 
        // We also have EntityReference properties.These classes have more members.
        //public static void QueryPersons()
        //{
        //    using (AdventureWorks2008Entities dbentities = new AdventureWorks2008Entities())
        //    {
        //        //ObjectSet<Person> people = dbentities.People;
        //        var people = from c in dbentities.People
        //                     where c.FirstName.Contains("ro")
        //                     select c;
        //        foreach (Person person in people)
        //        {
        //            Console.WriteLine("{0} {1}",
        //                        person.FirstName.Trim(),
        //                        person.LastName);
        //        }
        //    }
        //    Console.Write("Press Enter...");
        //    Console.ReadLine();
        //}

        //public static void QuerywithObjectServies()
        //{
        //    using (AdventureWorks2008Entities dbentities = new AdventureWorks2008Entities())
        //    {
        //        var queryString = "Select Value c " +
        //            "From AdventureWorks2008Entities.People AS c " +
        //            "Where c.FirstName='Robert'";
        //        ObjectQuery<Person> people = dbentities.CreateQuery<Person>(queryString);
        //        foreach (Person person in people)
        //        {
        //            Console.WriteLine("{0} {1}",
        //                        person.FirstName.Trim(),
        //                        person.LastName);
        //        }

        //    }
        //}

        public static void CreateNewPatient()
        {
            var dog = new AnimalType { TypeName = "Dog" };
            var Patient = new Patient
            {
                Name = "Sampson",
                BirthDate = new DateTime(2008, 1, 3),
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
                context.Patients.Add(Patient);
                context.SaveChanges();
            }
        }
    }
}
