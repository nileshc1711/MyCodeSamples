using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleCsharpLearn
{

    //TODO:- Generic Classes
    public class NamedContainer<T>
    {

        public NamedContainer(T item, String name)
        {
            Item = item;
            Name = name;
        }
        public T Item { get; private set; }
        public String Name { get; private set; }
        public void SomeFun()
        {
            Console.WriteLine(Item + "Inside Class");
            Console.WriteLine(Name + "Inside Class");
        }
    }
    #region New Constraint Example
    //TODO: Generics NEW() Instance Constraints
    public static class Deferred<T>
        where T : new()
    {
        private static T _instance;
        public static T instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                }
                return _instance;
            }
        }
    }
    //TODO: Generics Type Constraints
    #endregion

    #region Type Constraint Example
    public class GenericComparer<T> : IComparer<T>
    where T : IComparable<T>
    {
        public Int32 Compare(T x, T y)
        {
            return x.CompareTo(y);

        }
        public static void PrintDefault<T>()
        {
            Console.WriteLine(default(T));
        }
        public static T GetLast<T>(T[] items)
        {
            return items[items.Length - 1];
        }
        public static T MakeFake<T>()
            where T : class
        {
            return (T)(object)new List<T>();
        }

    }
    #endregion

    #region Reference Constraint Example
    /// <summary>
    /// This constraint helps enables you to do three things 
    /// Check nulls - only referenc type as null values
    /// Use the "as" operator - this operator produces the value as null as well so reference is required
    /// use one Generic parameter for another   
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Bar<T>
        where T : class
    {
        //code goes here
    }
    /// <summary>
    /// scenario where we would need this kind of constraint where structs cant work 
    /// </summary>
    /// <typeparam name="TSubject"></typeparam>
    /// <typeparam name="TFake"></typeparam>
    public class TestBase<TSubject, TFake>
        where TSubject : new()
        where TFake : class, new()
    {
        public TSubject Subject { get; private set; }
        public TFake Fake { get; private set; }

        public void Initialize() 
        {
            Subject = new TSubject();
            Fake = new TFake();
        }

        #region Generic Method with Default Keyword example
        public void PrintDefault<T>() 
        {
            Console.WriteLine(default(T));
        }

        public static T GetLast<T>(T[] items) 
        {
            return items[items.Length - 1];
        }

        public static TFake MakeFake<T>()
            where T : class ,new() 
        {
            return new TFake();
        }

        #endregion
    }

    #endregion
}