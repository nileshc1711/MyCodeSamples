using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDesignPatterns.IntroSampleDesign
{
    public abstract class Duck
    {
        internal IQuackBehavior quackBehavior;
        internal IFlyBehaviour flyBehaviour;

        public Duck()
        {

        }

        public abstract void display();

        public void PerformFly()
        {
            flyBehaviour.fly();
        }

        public void SetFlyBehavior(IFlyBehaviour fb)
        {
            flyBehaviour = fb;
        }

        public void SetQuackBehavior(IQuackBehavior qb)
        {
            quackBehavior = qb;
        }

        public void PerformQuack()
        {
            quackBehavior.Quacks();
        }

        public void Swim()
        {
            Console.WriteLine("All ducks float,even decoys !!");
        }
    }

    public class MallardDuck : Duck
    {
        public MallardDuck()
        {
            quackBehavior = new Quack();
            flyBehaviour = new FlyWithWings();
        }
        public override void display()
        {
            Console.WriteLine("I’m a real Mallard duck");
        }
    }

    public class ModelDuck : Duck
    {
        public ModelDuck()
        {
            flyBehaviour = new FlyNoWay();
            quackBehavior = new Quack();
        }

        public override void display()
        {
            Console.WriteLine("I’m a model duck");
        }
    }
}
