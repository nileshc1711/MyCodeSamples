using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCsharpLearn
{
    class TestLinq
    {
        IEnumerable<CultureInfo> commaCultures = from culture in CultureInfo.GetCultures(CultureTypes.AllCultures)
                                                 where culture.NumberFormat.NumberDecimalSeparator == ","
                                                 select culture;

        IEnumerable<CultureInfo> cultureinfo1 = CultureInfo.GetCultures(CultureTypes.AllCultures).Where(x => x.NumberFormat.NumberDecimalSeparator == ",");

        //Query with 'let' clause
        IEnumerable<String> cultureinfo2 = from culture in CultureInfo.GetCultures(CultureTypes.AllCultures)
                                           let numFormat = culture.NumberFormat
                                           where numFormat.NumberDecimalSeparator == ","
                                           select culture.Name;


        //the same effect with ordinary method calls
        IEnumerable<String> cultureinfo3 = CultureInfo.GetCultures(CultureTypes.AllCultures)
                                            .Select(culture => new { Name = culture.Name, numformat = culture.NumberFormat })
                                            .Where(vars => vars.numformat.NumberDecimalSeparator == ",")
                                            .Select(vars => vars.Name);

    }
    //Supporting Query Expressions -> as all the Linq expressions are converted to method calls
    public class SillyLinqProvider
    {
        public SillyLinqProvider Where(Func<String, Int32> pred)
        {
            Console.WriteLine("Where Invoked");
            return this;
        }

        public String Select<T>(Func<DateTime, T> map)
        {
            Console.WriteLine("Select Invoked with type argument " + typeof(T));
            return "This operator makes no sense";
        }
        public void SomeFun()
        {
            // This code does not compile but demostrates that LINQ providers just wants expected methods
            //var q = from x in new SillyLinqProvider()
            //        Where int.Parse(x)
            //         Select x.Hour; 

            //var abc = new SillyLinqProvider.Where(x => Int32.Parse(x)).Select(x=> x.Hour);
        }

    }

    //Custom Linq Provider for CultureInfo[]
    public static class CustomLinqProvider
    {
        public static CultureInfo[] Where(this CultureInfo[] cultures, Predicate<CultureInfo> filter)
        {
            return Array.FindAll(cultures, filter);
        }
        public static T[] Select<T>(this CultureInfo[] cultures, Func<CultureInfo, T> map)
        {
            var result = new T[cultures.Length];
            for (int i = 0; i < cultures.Length; ++i)
            {
                result[i] = map(cultures[i]);
            }
            return result;
        }
    }

    //Defferred Evaluation
    //To see Defferred Execution lets try an example for Fibonnaci series
    class DeferredEgUsingFibonnaci
    {
        public static IEnumerable<BigInteger> Fibonacci()
        {
            BigInteger n1 = 1;
            BigInteger n2 = 1;
            yield return n1;
            while (true)
            {
                yield return n2;
                BigInteger t = n1 + n2;
                n1 = n2;
                n2 = t;
            }

        }
    }

    //Example 10-13. A custom deferred Where operator
    public static class CustomDeferredLinqProvider
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> src, Func<T, Boolean> filter)
        {
            foreach (T item in src)
            {
                if (filter(item))
                {
                    yield return item;
                }
            }
        }
    }

    public interface IQueryable : IEnumerable
    {
        Type ElementType { get; }
        Expression expression { get; }
        IQueryProvider provider { get; }

    }

    public interface IQueryable<out T> : IEnumerable<T>, IQueryable
    {

    }
    public interface IQueryProvider
    {
        IQueryable CreateQuery(Expression expression);
        IQueryable<TElement> CreateQuery<TElement>(Expression expression);
        Object Execute(Expression expression);
        TResult Excute<TResult>(Expression expression);

    }


    //Example 10-17. Sample input data for LINQ queries
    public class Course
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public int Number { get; set; }
        public DateTime PublicationDate { get; set; }
        public TimeSpan Duration { get; set; }

        public static readonly Course[] catalog = { 
                                                      new Course{Title = "Elements of Geometry",
                                    Category = "MAT", Number = 101, Duration = TimeSpan.FromHours(3),
                                    PublicationDate = new DateTime(2009, 5, 20)},
new Course{
                        Title = "Squaring the Circle",
                        Category = "MAT", Number = 102, Duration = TimeSpan.FromHours(7),
                        PublicationDate = new DateTime(2009, 4, 1)
},
new Course {
Title = "Recreational Organ Transplantation",
Category = "BIO", Number = 305, Duration = TimeSpan.FromHours(4),
PublicationDate = new DateTime(2002, 7, 19)
},
new Course
{
Title = "Hyperbolic Geometry",
Category = "MAT", Number = 207, Duration = TimeSpan.FromHours(5),
PublicationDate = new DateTime(2007, 10, 5)
},
new Course
{
Title = "Oversimplified Data Structures for Demos",
Category = "CSE", Number = 104, Duration = TimeSpan.FromHours(2),
PublicationDate = new DateTime(2012, 2, 21)
},
new Course
{
Title = "Introduction to Human Anatomy and Physiology",
Category = "BIO", Number = 201, Duration = TimeSpan.FromHours(12),
PublicationDate = new DateTime(2001, 4, 11)
},
                                               };
        #region FilterOperator
        public static void Filter() 
        {
            //There is an overloaded extension method for Where Clause which takes an INT index as the second parameter
            IEnumerable<Course> q = Course.catalog.Where(
                (course, index) =>  (index % 2 == 0) && course.Duration.TotalHours >= 3
                );
        }


        /// <summary>
        ///LINQ defines another filtering operator: OfType<T>
        ///Example 10-19. The OfType<T> operator
        /// . This is useful if your source con
        ///tains a mixture of different item types—perhaps the source is an IEnumerable<ob
        ///ject> and you’d like to filter this down to only the items of type string
        /// </summary>
        /// <param name="src"></param>
        public static void ShowAllStrings(IEnumerable<Object> src) 
        {
            var _strings = src.OfType<String>();
            foreach (String s in _strings) 
            {
                Console.WriteLine(s);
            }
        }
        #endregion
        #region SelectOperator
        public static void SelectOpert() 
        {
            IEnumerable<String> nonIntro = Course.catalog.Select(
                (course,index) => String.Format("Course {0} : {1}",index+1,course.Title)
                );
            //Indexed Select downstream of Where operator
            IEnumerable<String> DownnonIntro = Course.catalog.Where(
                c=> c.Number >=200
                ).Select(
                (course,index)=>  String.Format("Course {0} : {1}",index+1,course.Title)
                );

            //Indexed Select upstream of Where operator
            IEnumerable<String> UpnonIntro = Course.catalog
                .Select((course,index)=> new {course,index})
                .Where(vars => vars.course.Number >=200)
                .Select(vars => String.Format("Course {0} : {1}",vars.index+1,vars.course.Title));
        }
        #endregion
    }
}
