using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCSharpinDepth
{
   public class SomeRefType 
    {
        public  int i;
    }

    class Program
    {
       static void Foo(SomeRefType refy) 
        {
            refy.i = 10;
            refy = null;
            Console.WriteLine(refy==null);
        }

        static void Main(string[] args)
        {
            SomeRefType r = new SomeRefType { i= 5};
            Foo(r);
            Console.WriteLine(r.i);
            Console.WriteLine(r == null);
            Console.ReadKey();
        }
    }
}
