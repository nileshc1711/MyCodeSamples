using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCsharpLearn
{

    class Program
    {
        static void Main(string[] args)
        {
            //ArgumentTest text = new ArgumentTest();

            //TimePeriod t = new TimePeriod();
            //Console.WriteLine("Time in Hours" + t.Hours);
            //t.Hours = 34;
            //Console.WriteLine("Time in Hours" + t.Hours);

            //LINQ
            //var commaCultures = from culture in CultureInfo.GetCultures(CultureTypes.AllCultures)
            //                    where culture.NumberFormat.NumberDecimalSeparator == ","
            //                    select culture.Name;

            //foreach (String Name in commaCultures) 
            //{
            //    Console.WriteLine(Name);
            //}
            //var evenFib = from n in DeferredEgUsingFibonnaci.Fibonacci()
            //              where n % 2 == 0
            //              select n;

            //foreach (BigInteger n in evenFib)
            //{
            //    Console.WriteLine(n);
            //}

            //var commaCultures = (from c in CultureInfo.GetCultures(CultureTypes.AllCultures)
            //                   where c.NumberFormat.NumberDecimalSeparator == ","
            //                   select c);

            //Object[] numbers = { 1, 100, 100.2, 10000.2 };

            //foreach (object number in numbers) 
            //{
            //    foreach (CultureInfo culture in commaCultures)
            //    {
            //        Console.WriteLine(string.Format(culture, "{0}: {1:c}",
            //        culture.Name, number));
            //    }
            //}


            //EVENTS
            //var source = new Eventful();
            //source.Announce("Hello World Event");
            //source.Announcement += m => Console.WriteLine("Announcement :" + m);
            //source.Announce("Hello World Event");
            
            //Ch9EventsnDelegates
            //var zeroThreshold = new ThresholdComparer { Threshold= 0 };
            //var tenThreshold = new ThresholdComparer { Threshold = 10 };
            //var hundredThreshold = new ThresholdComparer { Threshold = 100 };
            //Predicate<int> greaterThanZero = zeroThreshold.isGreateThan;
            ////Predicate<Int32> greaterThanten = tenThreshold.isGreateThan;
            //Predicate<Int32> greaterThanten = tenThreshold.GetisGreaterThanPredicate();
            //Predicate<Int32> greaterThanHundred = hundredThreshold.isGreateThan;

            //ThresholdComparer.Caught();

           // Predicate<Object> po = EventsTest.IsLongString;
           // Predicate<String> ps = po;
           //// Func<String, Boolean> fn = ps; //This is non compile code which is used to see that delegates with same method signatures are not compatible.But we have a work around look next step
           // var pred2 = new Func<String, Boolean>(ps);
           // var pred3 = new Func<String, Boolean>(ps.Invoke); // referring to the second predicate not the method ,and the second predicate refers to d actual method
           // //Or more directly reference to the method like below
           // var pred4 = (Func<String, Boolean>)Delegate.CreateDelegate(typeof(Func<String, Boolean>), ps.Target, ps.Method);
 
           // Console.WriteLine(ps("Too Short"));

           // //CH7ObjLifetime
           //// String res = ObjLifetest.GetBlogEntry("Hello");
           // var cache = new WeakCache<String, Byte[]>();
           // var data = new Byte[100];
           // cache.Add("D", data);

           // Byte[] fromCache;
           // Console.WriteLine("Retrival:" +cache.TryGetValue("D", out fromCache));
           // Console.WriteLine("Same Ref? :" + object.ReferenceEquals(data, fromCache));
           // fromCache = null;

           // GC.Collect();
           // Console.WriteLine("Retrival:" + cache.TryGetValue("D", out fromCache));
           // Console.WriteLine("Same Ref? :" + object.ReferenceEquals(data, fromCache));
           // fromCache = null;

           // data = new Byte[100];
           // GC.Collect();
           // Console.WriteLine("Retrieval: " + cache.TryGetValue("D", out fromCache));
           // Console.WriteLine("Null? " + (fromCache == null));


            //EntitiesTestClass Test
            //EntitiesTestClass.QueryPersons();
           // EntitiesTestClass.QuerywithObjectServies();
           // EntitiesTestClass.CreateNewPatient();

            //Inheritance test
            //ISample isample = new Derived();
            //isample.ImplementSomeThing();
            
            // isample = new AlsoDerived();
            // isample.ImplementSomeThing();
            // isample = new Base();
            //isample.ImplementSomeThing();


            //Base b = new Base();
            //Derived d = (new AlsoDerived());
            //AlsoDerived ad = new AlsoDerived();

            //DerivedInt drint = new DerivedInt();

            //IEnumerable<Derived> derivedbase = new Derived[] { new Derived(), new Derived() };

            //ad.AllyourBase(derivedbase);

            //ICollection<Derived> derivedList = new List<Derived>();

           // ad.Addbase(derivedbase);

            //Console.WriteLine("Main");
            //InitializationTestClass.Foo();
            //Console.WriteLine("Construcing 1 ");
            //InitializationTestClass tstclass = new InitializationTestClass();
            //Console.WriteLine("Construcing 2 ");
            //tstclass = new InitializationTestClass();
            //Int32 z ;
            //AfterYou.Divide(10, 3, out z);
            //var a = new NamedContainer<Int32>(49, "The Answer");
            //var b = new NamedContainer<String>("Programming C#", "The Answer");
            //var namedInts = new List<NamedContainer<Int32>>() { a, new NamedContainer<Int32>(1, "Test"), new NamedContainer<Int32>(2, "Test") };
            //Console.WriteLine(namedInts[0].Item);
            //Console.WriteLine(namedInts[0].Name);
            //Console.WriteLine(namedInts[1].Item);
            //Console.WriteLine(namedInts[1].Name);
            //a.SomeFun();
            //Console.WriteLine(a.Item);
            //Console.WriteLine(b.Item);
            //foreach (Int32 i in Ch5Collections.ThreeNumbers())
            //{
            //    Console.WriteLine(i);
            //}
            
            //IEnumerable<Int32> en = Ch5Collections.ThreeNumbers();
            //foreach (Int32 i in Ch5Collections.Numbers(1, 5))
            //{
            //    Console.WriteLine(i);
            //}

            //var numbers = new[] {-4,-3,-6,0, 1, 2, 0,-2,-5, 56, 465 };
            //Console.WriteLine(Ch5Collections.GetIndexOfFirstNonEmptyBin(numbers));

            //sCounter sc = new sCounter();
            //sc++;
            //sCounter sc1 = sc;
            //Int32 c1 = new Int32();
            //c1++;
            //Int32 c2 = c1;
            //Int32 c3 = new Int32();
            //c3++;
            Counter c1 = new Counter();
            Counter c2 = c1;
            c1++;
            Console.WriteLine("c1: " + c1.Count);
            c1++;
            Console.WriteLine("c1: " + c1.Count);
            c1.GetNextValue();
            Console.WriteLine("c1: " + c1.Count);
            c2++;
            Console.WriteLine("c2: " + c2.Count);
            c1++;
            Console.WriteLine("c1: " + c1.Count);
            //Console.WriteLine(c1);
            //Console.WriteLine(c2);
            //Console.WriteLine(c3);
            //Console.WriteLine(c1 == c2);
            //Console.WriteLine(c1 == c3);
            //Console.WriteLine(c2 == c3);
            //Console.WriteLine(object.ReferenceEquals(c1, c2));
            //Console.WriteLine(object.ReferenceEquals(c1, c3));
            //Console.WriteLine(object.ReferenceEquals(c2, c3));
            Console.ReadLine();
        }
    }
}
