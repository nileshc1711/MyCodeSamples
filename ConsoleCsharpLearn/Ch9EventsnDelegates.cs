using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCsharpLearn
{
    class EventsTest
    {
        public static int GetIndexOfFirstNonEmptyBin(int[] bins)
        {
            Predicate<int> p = IsGreaterThanZero;
            var p1 = new Predicate<int>(IsGreaterThanZero); 

            return Array.FindIndex(bins, IsGreaterThanZero);
        }
         
        private static bool IsGreaterThanZero(int value)
        {
            return value > 0;
        }

        public static void TestForMajority(Predicate<int> UserCallbacks) 
        {
            int truecount = 0;
            int falsecount = 0;
            foreach (Predicate<Int32> p in UserCallbacks.GetInvocationList()) 
            {
                bool result = p(42);
                if (result)
                {
                    truecount += 1;

                }
                else 
                {
                    falsecount += 1;
                }
            }
            if (truecount > falsecount) 
            {
                Console.WriteLine("The majority returned true");
            }
            else if (falsecount > truecount) { Console.WriteLine("The majority returned true"); }
            else 
            {
                Console.WriteLine("Its a Tie");
            }
        }
        public static bool IsLongString(Object o) 
        {
            var s = o as String;
            return s != null && s.Length > 20;
        }

        //Writing inline Methods instead of the target obj which refers to the actual methods .So this means that you can define the method inline.
        public static Int32 GetIndexOfFirstNonEmptyBinWithDelegate(Int32[] bins) 
        {
            return Array.FindIndex<Int32>(bins,
                delegate(Int32 value) { return value > 0; });  //The delegate keyword refers to the anonymous funtion i:e it takes the function name.
        }

        //Now the Lambda syntax for the same
        public static Int32 GetIndexOfFirstNonEmptyBinWithLambda(Int32[] bins)
        {
            return Array.FindIndex<Int32>(bins,
              X=> X > 0);  //The delegate keyword refers to the anonymous funtion i:e it takes the function name.
        }
        Predicate<Int32> p = value => value > 0;
        Predicate<Int32> p1 = (value) => value > 0; // Put paranthesis for the paramters in multiparameter lambdas, single paramter can be omitted
        Predicate<Int32> p2 = (Int32 value) => value > 0; // Put paranthesis  if you define the parameter type even if single parameter
        Predicate<Int32> p3 = value => { return value > 0; }; // You can use the code block as well but need to mention the RETRUN statment then
        Predicate<Int32> p4 = (value) => { return value > 0; };
        Predicate<Int32> p5 = (Int32 value) => { return value > 0; }; 

        //You can also write d lambda that does not take any arguments,see below
        Func<Boolean> isAfternoon = () => DateTime.Now.Hour >= 12;

    }

    public class ThresholdComparer 
    {
        public int Threshold { get; set; }

        public bool isGreateThan(int value) 
        {
            return value > Threshold;
        }

        public Predicate<int> GetisGreaterThanPredicate(Int32 threshold) 
        {
            //return isGreateThan;
            return value => value > threshold; //lambdas can take the variables as well which are in scope
        }
        public delegate void Action();

        public static void Caught() 
        {
            var GreaterThan = new Predicate<Int32>[10];
            for (Int32 i = 0; i < GreaterThan.Length; ++i) 
            {
                GreaterThan[i] = value => value > i; //Bad Use of is
            }
           Console.WriteLine(GreaterThan[5](20));
            Console.WriteLine(GreaterThan[5](6));
        }
    }

    //EVENTS 
    public class Eventful 
    {
        public event Action<String> Announcement;

        private  Action<String> Announcement1;
        // Not the actual code.
        // The real code is more complex, to tolerate concurrent calls
        public void add_Announcement1(Action<String> handler) 
        {
            Announcement1 += handler;
        }
        public void remove_Announcement1(Action<String> handler)
        {
            Announcement1 -= handler;
        }



        public void Announce(String message) 
        {
            if (Announcement != null) 
            {
                Announcement(message);
            }
        }

    }

    //Custom Add and Remove methods from Events
    public class ScarceEventSource 
    {
        // One dictionary shared by all instances of this class,
        // tracking all handlers for all events.
        public static readonly
            Dictionary<Tuple<ScarceEventSource, object>, EventHandler> _eventhandler = new Dictionary<Tuple<ScarceEventSource, object>, EventHandler>();

        // Objects used as keys to identify particular events in the dictionary.
        public static readonly object EventOneId = new object();
        public static readonly object EventTwoId = new object();


    }
}
