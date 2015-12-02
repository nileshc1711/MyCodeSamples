using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCSharpinDepth
{

    #region Chapter-2 Beginning with Delegates

    public delegate void StringProcessor(String input);

    class Person {
        string name;

        public Person(String name) {
            this.name = name;
        }

        public void Say(String message) {
            Console.WriteLine("{0} says: {1}", message);
        }
    }

    class Background {
        public static void Note(String note) 
        {
            Console.WriteLine("({0})", note);
        }
    
    }

    #endregion
}
