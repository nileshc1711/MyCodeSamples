using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleCSharpinDepth
{
    

    class Program
    {
       

        static void Main(string[] args)
        {
        
            #region Chapter 1 - Starting- Simple DataTypes
            var products = Product3.GetSampleProducts();

            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
            }



            #region Sorting and Searching

            var prodList = Product.GetSampleProducts();
            prodList.Sort(new ProductComparer());

            foreach (var product in prodList)
            {
                Console.WriteLine(product.ToString());
            }


            var prods = Product4.GetSampleProducts();
            prods.Sort(new ProductComparer());
            foreach (var product in prods)
            {
                Console.WriteLine(product);
            }


            #endregion

            #region Querying Collections
            var list = Product3.GetSampleProducts();

            Predicate<Product3> Test = delegate(Product3 p) { return p.Price > 10m; };
            var matches = list.FindAll(Test);

            Action<Product3> print = Console.WriteLine;

            matches.ForEach(print);

            list.FindAll(delegate(Product3 p) { return p.Price > 10m; })
                               .ForEach(Console.WriteLine);
            Console.WriteLine("=====================================");
            list.Where(p => p.Price > 10m).ToList<Product3>().ForEach(Console.WriteLine);
            Console.WriteLine("=====================================");

            list.ForEach(p =>
            {
                if (p.Price > 10m)
                    Console.WriteLine(p);
            });

            var filtered = from p in list
                           where p.Price > 10
                           select p;



            #endregion

            #region Querying XML data

            Product4.QueryXMLData();
            #endregion

            #region COM Interop
            Product4.SaveDataToExcel();
            #endregion

            #endregion


            #region Delegate- Chapter -2
            Person jon = new Person("jon");
            Person tom = new Person("tom");
            StringProcessor JonsVoice, TomsVoice, background;
            JonsVoice = new StringProcessor(jon.Say);
            TomsVoice = new StringProcessor(tom.Say);
            background = new StringProcessor(Background.Note);
            JonsVoice("Hello,Son");
            TomsVoice.Invoke("Hello, Daddy!");
            background("The World goes zoom..");


            #endregion

            Console.ReadKey();
        }
    }
}
