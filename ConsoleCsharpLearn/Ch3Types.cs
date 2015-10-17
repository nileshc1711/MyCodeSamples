using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleCsharpLearn
{
    #region ClassDemoCounter
    public class Counter
    {
        private readonly int _count;
        private static int _totalcount;
        public Counter()
        {
            _count = 0;
        }
        private Counter(int count)
        {
            _count = count;
        }
        public Counter GetNextValue()
        {
            //this._count += 1;
            _totalcount += 1;
            return new Counter(_count + 1);
        }
        public static Counter operator ++(Counter input)
        {
            return input.GetNextValue();
        }
        public int Count
        {
            get { return _count; }

        }
        public static int TotalCount
        {
            get { return _totalcount; }
        }
    }
    #endregion
    #region StructDemoCounter
    public  struct sCounter
    {
        private static int _count = 0;
        public const int someVal = 32;
        private static int _totalcount;

        private sCounter(int count)
        {
            _count = count;
        
        }
        public  sCounter GetNextValue()
        {
            
            //this._count += 1;
            _totalcount += 1;
            return new sCounter(_count + 1);
        }
        
        public static sCounter operator ++(sCounter input)
        {
            return input.GetNextValue();
        }
        public static bool operator ==(sCounter x, sCounter y)
        {
            return x.Count == y.Count;
        }
        public static bool operator !=(sCounter x, sCounter y)
        {
            return x.Count != y.Count;
        }
        public override bool Equals(object obj)
        {
            if (obj is sCounter)
            {
                sCounter c = (sCounter)obj;
                return c.Count == this.Count;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return _count;
        }
        public int Count
        {
            get { return _count; }

        }
        public static int TotalCount
        {
            get { return _totalcount; }
        }
    }

    #endregion

    #region Demo for Constructors
    /*The new keyword always invokes the constructor and the new ref obj is being created
     but this can be bypassed if the Type supports SERIALIZATION.If a class supports a CLR feature called serialization, objects of that type can be deseri
     alized directly from a data stream, bypassing constructors.Other wise creating an instance of a class almost  always involves using a constructor at some point.    
     */
    internal class ItemwithId
    {
        public ItemwithId()
        {
            _id = ++_lastid;
        }
        public ItemwithId(String name)
            : this()
        {
            _name = name;

        }
        public ItemwithId(Decimal price, String name)
        {
            _price = price;
            _name = name;
        }
        private readonly Decimal _price;
        private readonly String _name;
        private Int32 _lastid;
        private Int32 _id;
       
        
    }

    internal class Bar 
    {
        private static DateTime _firstUsed;
        static Bar() 
        {
            Console.WriteLine("Bar static constructor");
            _firstUsed = DateTime.Now;
        }
    }

    internal class InitializationTestClass 
    {
        public InitializationTestClass() 
        {
            Console.WriteLine("Instance Constructor");
        }
        static InitializationTestClass()
        { Console.WriteLine("Static Constructor"); }

        public static Int32 s1 = GetValue("Static Field 1");
        public  Int32 n1 = GetValue("Non- Static Field 1");
        public static Int32 s2 = GetValue("Static Field 2");
        public Int32 n2 = GetValue("Non- Static Field 2");
        public static Int32 GetValue(String msg) 
        {
            Console.WriteLine(msg);
            return 1;
        }
        public static void Foo()
        { Console.WriteLine("Static Method"); }
    }

    internal class AfterYou 
    {
        static AfterYou() 
        {
            Console.WriteLine("After u static conststir starting");
            Console.WriteLine("NoAfterYou.Value: " + NoAfterYou.Value);
            Console.WriteLine("AfterYou static constructor ending");
        }
        public static Int32 Value = 42;
        public static Int32 Divide(Int32 x, Int32 y, out Int32 remainder) 
        {
            remainder = x % y;
            return x / y;
        }
    }
    internal class NoAfterYou 
    {
        static NoAfterYou()
        {
            Console.WriteLine("NoAfterYou static constructor starting");
            Console.WriteLine("AfterYou.Value: " + AfterYou.Value);
            Console.WriteLine("NoAfterYou static constructor ending");
        }
        public static int Value = 42;
    }

#region For ExtensionMethods
    /*TODO: You are allowed to define extension methods only in Static Class*/
    public static class StringExtension 
    {
        public static void Show(this String s) 
        {
            System.Console.WriteLine(s);
            s.Show();    
        }
         
        
       
    }  
#endregion
#region For Indexers
/*TODO:Indexers are nothing but the properties which can take one or more arguments and are accessed
 the same way as syntax for arrays
 */
    public class Indexed 
    {
      //  public Indexed this[Int32 index] { get; set; }
        public static void Indexdemo()
        {
            var numbers = new List<int> { 1, 2, 3 };
            numbers[1] += numbers[2];
            Console.WriteLine(numbers[1]);
        }
    }
#endregion

    #endregion

    #region Demo for Methods optional and passing by Reference
            internal class ArgumentTest 
            {
                int r;
                int q;
                public ArgumentTest() 
                {
                    q = Divide(30,10, out r);
                    Console.WriteLine("{0} and {1}",r,q);
                    Blame();
                    Blame(problem: "the world's unrest");
                }

                private static int Divide(int x , int y , out int r ) 
                {
                    r = NewMethod(x, y);
                    return x / y;
                }

                private static int NewMethod(int x, int y)
                {
                    int r;
                    r = x % y;
                    Interlocked.Increment(ref r);
                    return r;
                }
                /// <summary>
                /// this is example for optional arguments
                /// </summary>
                /// <param name="perpetrator"></param>
                /// <param name="problem"></param>
                public static void Blame(string perpetrator ="the youth of today",  String problem ="The downfall of society") 
                {
                    Console.WriteLine("I Blame {0} for {1}", perpetrator, problem);
                }
            }
        #endregion

#region Properties From MSDN

            class TimePeriod 
            {
                double seconds;



                public virtual Double Hours
                {
                    get {
                       return Foo();
                        //return seconds / 3600; 
                    }
                    set { seconds = value * 3600; }
                }

                public Int32 Foo() 
                {
                    return 24;
                }
            }


#endregion

}

























