using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDesignPatterns.IntroSampleDesign
{
    public interface IQuackBehavior
    {
         void Quacks();
    }

    public class Quack : IQuackBehavior 
    {
        public void Quacks() 
        {
            Console.WriteLine("Quack");
        }
    }

    public class MuteQuack : IQuackBehavior 
    {
        public void Quacks()
        {
            Console.WriteLine("<<Silence>>");
        }
    }

    public class Squeak : IQuackBehavior 
    {
        public void Quacks()
        {
            Console.WriteLine("Squeak");
        }
    }
}
