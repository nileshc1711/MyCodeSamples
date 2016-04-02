using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*database Initializers*/
            EntityTest.Initialize();

            /*VetContext Context Methods*/
            //EntityTest.CreateNewPatient();

            /*BreakAway Context Methods*/
           // EntityTest.InsertDestination();
           // EntityTest.InsertTrip();
            //EntityTest.InsertPerson();
            //EntityTest.UpdateTrip();
            //EntityTest.UpdatePerson();
            EntityTest.DeleteDestinationInMemoryAndDbCascade();
        }
    }
}
