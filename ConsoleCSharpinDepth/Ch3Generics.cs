using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleCSharpinDepth
{
    #region Basic Example Generics
    #region Bare Classes For Covariance and Contravariance
    public class Soma { }

    public class Dos : Soma { }
    #endregion
    class Generics
    {
        public static Dictionary<String, Int32> CountWords(String text)
        {
            Dictionary<String, Int32> freq = new Dictionary<string, int>();
            String[] words = Regex.Split(text, @"\W+");

            foreach (String word in words)
            {
                if (freq.ContainsKey(word))
                {
                    freq[word]++;
                }
                else
                {
                    freq[word] = 1;
                }
            }
            return freq;
        }

        public static Double TakeSquareRoot(Int32 x)
        {
            return Math.Sqrt(x);
        }

        public static Dos Dosoma(Soma dos)
        {

            return new Dos();
        }

        public static void DoConversion()
        {

            List<Int32> integers = new List<int> { 1, 2, 3, 4 };

            Converter<Int32, Double> converter = Generics.TakeSquareRoot;

            Converter<Dos, Soma> con = Generics.Dosoma; // this is to demonstarte the covariance and contravariance

            var doubles = integers.ConvertAll(converter);
            foreach (double d in doubles)
            {
                Console.WriteLine(d);
            }

        }

        public static List<T> MakeList<T>(T first, T second)
        {

            List<T> list = new List<T>();
            list.Add(first);
            list.Add(second);
            return list;

        }

        public void GetStringList()
        {

            var stringList = MakeList("Line 1", "Line2");

            stringList.ForEach(x => Console.WriteLine(x));

        }
    }



    #endregion

    #region Beyond Basics --Constraints

    #region Reference/Value Constraints -- has to be first
    struct RefSample<T> where T : class
    {

    }

    class ValueSample<T> where T : struct
    {

    }

    #endregion

    #region CONSTRUCTOR TYPE CONSTRAINTS -- has to be last
    public class CreateInstance
    {

        public static T CreateInstances<T>() where T : new()
        {
            return new T();

        }


    }


    #endregion

    #region CONVERSION TYPE CONSTRAINTS
    class Sample<T> where T : Stream { }

    struct Sample1<T> where T : IDisposable { }

    class Sample2<T> where T : IComparable<T> { }

    class Sample4<T, U> where T : U { }

    #endregion
    #region  COMBINING CONSTRAINTS

    public class Sample1<T, U>
        where T : class
        where U : struct,T
    {
        //
    }

    #endregion

    #endregion
}
