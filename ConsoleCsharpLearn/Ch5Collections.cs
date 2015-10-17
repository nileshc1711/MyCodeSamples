using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Collections;

namespace ConsoleCsharpLearn
{
    /*TODO: Chapter5  Collections->Array Initialization*/
    class Ch5Collections
    {
        Int32[][] jagarrays = new Int32[5][]{
        new[] {1,2,3},
        new[] {1,2,3,4,5,6},
        new[] { 1, 2, 4 },
        new[] { 1 },
        new[] { 1, 2, 3, 4, 5 }
        };
        int[,] grid = new Int32[5, 10];

        Int32[,] smallGrid = new[,] {
        {1,2,3,6},
        {1,2,3,5},
        {1,2,3,6}
        };

        /// <summary>
        /// //Creation of array with Immutable elements
        /// </summary>
        public void Create_ImmuatableElementsInArray() {
            var values = new Complex[10];
            values[0] = new Complex(10, 1);

            //Simple array Initialization
            var weekDays = new String[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Fridday" };
            var Weekdays = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Fridday" };
            String[] WeekDays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Fridday" };

        }
        

        String[] workingDaysNames = new String[0];

        /*List<T> Collections Classes*/


        public static string GetCopyRights(object o)
        {
            var numbers = new List<Int32>();
            numbers.Add(1234);
            numbers.Add(99);
            numbers.Add(42);
            numbers.TrimExcess();
            Console.WriteLine(numbers.Count);
            Console.WriteLine("{0}, {1}, {2}", numbers[0], numbers[1], numbers[3]);
            numbers[1] += 1;
            Console.WriteLine(numbers[1]);
            numbers.RemoveAt(1);
            Console.WriteLine(numbers.Count);
            Console.WriteLine("{0},{1}", numbers[0], numbers[1]);


            Assembly asm = o.GetType().Assembly;
            var CopyrightAttribute = (AssemblyCopyrightAttribute)
                asm.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), true)[0];

            return CopyrightAttribute.Copyright;
        }
        public String[] InitializeArray(String[] args)
        {

            args[0] = "Monday";
            args[1] = "Tuesday";
            args[2] = "Wednesday";
            args[3] = "Thursday";
            args[4] = "Friday";
            return args;
        }
        public void GetArray()
        {


            var workingDaysNames = new String[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            var workingDays = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            String[] workingWeekDayNames = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            workingDaysNames = InitializeArray(new[] { "Saturday", "Sunday" });
            Console.WriteLine("PI: {0}. Square root of 2: {1}", Math.PI, Math.Sqrt(2));
            Console.WriteLine("It is currently {0}", DateTime.Now);
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}", 1, 2, 3, 4, 5);

            int CurrentIndex = Array.IndexOf(workingWeekDayNames, "Wednesday");/*Array IndexOf Method to find the Index for some particular element in the Array*/
        }

        /*Variable Argument Count with the params Keyword*/
        public static void WriteLine(String format, params object[] args)
        {
            //Write Something here
        }

        public static int GetIndexOfFirstNonEmptyBin(int[] bins)
        {
            //return Array.FindIndex(bins, IsGreaterThanZero); //This works but  below is cool
            return Array.FindIndex(bins, x => x > 0);
        }

        private static bool IsGreaterThanZero(int value)
        {

            return value > 0;
        }

        //Generic Array to get all the Matching values from Array.FindAll() method
        public T[] GetNonNullItems<T>(T[] items)
            where T : class
        {
            List<String> abc = new List<string> { "Hello","World"};
            //abc.Where(
            return Array.FindAll(items, value => value != null);
        }

        public static IEnumerable<Int32> Numbers(Int32 start, Int32 count)
        {
            for (Int32 i = 0; i < count; i++)
            {
                yield return start + i;
            }
        }
        public static IEnumerable<Int32> ThreeNumbers()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }
    }

    class FibonacciEnumerable : IEnumerable<BigInteger>, IEnumerator<BigInteger>
    {
        private BigInteger v1, v2;
        private bool first = true;

        public BigInteger Current
        {
            get { return v1; }
        }
        public void Dispose()
        {

        }
        object IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            if (first)
            {
                v1 = 1;
                v2 = 1;
                first = false;
            }
            else
            {
                var tmp = v2;
                v2 = v1 + v2;
                v1 = tmp;
            }
            return true;
        }
        public void Reset()
        {
            first = true;
        }
        public IEnumerator<BigInteger> GetEnumerator()
        {
            return new FibonacciEnumerable();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
