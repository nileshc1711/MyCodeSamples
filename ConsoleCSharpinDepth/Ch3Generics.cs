using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleCSharpinDepth
{
    #region Basic Example Generics
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
                else {
                    freq[word] = 1;
                }
            }
            return freq;
        }

        public static Double TakeSquareRoot(Int32 x) 
        {
            return Math.Sqrt(x);
        }


        public static void DoConversion() {

            List<Int32> integers = new List<int> { 1, 2, 3, 4 };

            Converter<Int32, Double> converter = Generics.TakeSquareRoot;

            var doubles = integers.ConvertAll(converter);
            foreach (double d in doubles) {
                Console.WriteLine(d);
            }

        }
    }
    #endregion
}
