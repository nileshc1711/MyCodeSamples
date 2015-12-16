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
            EntityTest.Initialize();


           // EntityTest.CreateNewPatient();
           // EntityTest.InsertDestination();
            EntityTest.InsertTrip();
            EntityTest.InsertPerson();
        }
    }
}
