using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCsharpLearn
{
    class ObjLifetest
    {
        public static String GetBlogEntry(String relativeUri) 
        {
            var baseUri = new Uri("http://www.interact-sw.co.uk/iangblog/");
            var fullUri = new Uri(baseUri, relativeUri);
            using(var w = new WebClient()){
                return w.DownloadString(fullUri);
            }
        }

        public static void DonotWritethisCode() 
        {
            var numbers = new List<String>();
            long total = 0;
            for (int i = 1; i < 100000; ++i) 
            {
                numbers.Add(i.ToString());
                total += i;
 
            }
            Console.WriteLine("Total :{0},Average: {1}", total, total / numbers.Count);
        }

    }
    /// <summary>
    /// CheckOut the WeakReference Class for Garbage Collection
    /// </summary>
    /// <typeparam name="Tkey"></typeparam>
    /// <typeparam name="Tvalue"></typeparam>
    public class WeakCache<Tkey, Tvalue> where Tvalue : class
    {
        private Dictionary<Tkey, WeakReference<Tvalue>> _cache = new Dictionary<Tkey, WeakReference<Tvalue>>();

        public void Add(Tkey key, Tvalue value) 
        {
            _cache.Add(key, new WeakReference<Tvalue>(value));

        }

        public bool TryGetValue(Tkey key, out Tvalue cachedItem) 
        {
            WeakReference<Tvalue> entry;
            if (_cache.TryGetValue(key, out entry))
            {
                bool isAlive = entry.TryGetTarget(out cachedItem);
                if (isAlive)
                {
                    //_cache.Remove(key);
                }
                return isAlive;
            }
            else 
            {
                cachedItem = null;
                return false;
            }
        }
    }
}
