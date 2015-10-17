using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCsharpLearn
{
    public class Base : ISample
    {
        Int32 _base = 10;
        public void ImplementSomeThing()
        {
            Console.WriteLine("Interface Implemented of Base  ");
        }
    }
    public class Derived : Base
    {
        Int32 _derived = 20;
        public void ImplementSomeThing()
        {
            Console.WriteLine("Interface Implemented of Derived  ");
        }
    }
    public class AlsoDerived : Derived
    {
        Int32 _alsobase = 30;
        public void MightUseasDerived(Base b)
        {
            var d = b as Derived;
            if (d != null)
            {
                Console.WriteLine("This is being called");
            }
        }
        public void AllyourBase(IEnumerable<Base> bases)
        {
            //Do Something;
        }
        public void Addbase(ICollection<Base> bases)
        {
            // bases.Add(new Base());
            //using (AdventureWorks2008Entities advenContext = new AdventureWorks2008Entities())
            //{
            //    //
            //}
        }
        public void ImplementSomeThing() 
        {
            Console.WriteLine("Interface Implemented of AlsoDerived ");
        }
    }

    public class GenericBase1<T>
    {
        public T item { get; set; }
    }
    public class GenericBase2<Tkey, Tvalue>
    {
        public Tkey key { get; set; }
        public Tvalue value { get; set; }
    }
    public class NonGenericDerived : GenericBase1<String>
    {
        //Do Something;
    }
    public class GenericDerived<T> : GenericBase1<T>
    {
        //Do Something;
    }
    public class MixedDerived<T> : GenericBase2<T, String>
    { //Do Something;

    }
    /// <summary>
    /// This verifies that the derived type’s field initializers run first, and then the base field
    ///initializers, followed by the base constructor, and then finally the derived constructor.
    ///In other words, although constructor bodies start with the base class, instance field
    ///initialization happens in reverse.
    ///THATS WHY YOU DONT GET TO INVOKE INSTANCE METHOD ON FIELD INITIALIZERS .STATIC METHODS ARE AVAIALABLE BUT INSTANCE METHODS ARE NOT
    /// </summary>
    public class BaseInt
    {
        protected static int Init(String message)
        {
            Console.WriteLine(message);
            return 1;
        }
        private int b1 = Init("Base Field B1");

        public BaseInt()
        {
            Console.WriteLine("Base Constructor");
        }
        private int b2 = Init("Base Field B2");

    }

    public class DerivedInt : BaseInt
    {
        private Int32 d1 = Init("derived Field D1");

        public DerivedInt()
        {
            Init("Derived Constructor");
        }
        private Int32 d2 = Init("derived Field D2");
    }

    public interface ISample 
    {
        void ImplementSomeThing();
    }

}



















