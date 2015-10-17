using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDesignPatterns.IntroSampleDesign
{
     public interface IFlyBehaviour
    {
          void fly();
    }

     public class FlyWithWings : IFlyBehaviour 
     {
         public void fly() 
         {
             Console.WriteLine("I'm Flying !!");
         }
     }

     public class FlyNoWay : IFlyBehaviour 
     {
         public void fly() 
         {
             Console.WriteLine("I can't fly !!");
         }
     }

     public class FlyRocketPowered : IFlyBehaviour 
     {
         public void fly()
         {
             Console.WriteLine("I’m fl ying with a rocket!");
         }
     }
}
