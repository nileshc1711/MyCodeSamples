using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Office.Interop.Excel;

namespace ConsoleCSharpinDepth
{
    #region Starting with a simple data type

    /// <summary>
    ///  The Product Type -C# 1
    /// </summary>
    class Product
    {
        String name;
        public String Name
        {
            get
            {
                return name;
            }
        }
        Decimal price;
        public Decimal Price
        {
            get
            {
                return price;
            }
        }

        public Product(String name, Decimal price)
        {
            this.name = name;
            this.price = price;
        }

        public static ArrayList GetSampleProducts()
        {
            ArrayList products = new ArrayList();
            products.Add(new Product("West side story", 9.99m));
            products.Add(new Product("Assassins", 19.99m));
            products.Add(new Product("Frog", 29.99m));
            products.Add(new Product("Sweeney Todd", 69.99m));
            return products;
        }

        public override string ToString()
        {
            //return base.ToString();
            return String.Format("{0} : {1}", name, price);
        }

    }

    /// <summary>
    ///  The Product Type -C# 2
    ///  Strongly Typed collections and Private Setters
    /// </summary>
    class Product2
    {
        String name;
        public String Name
        {
            get
            {
                return name;
            }

            private set
            {
                name = value;
            }

        }
        Decimal price;
        public Decimal Price
        {
            get
            {
                return price;
            }
            private set
            {
                price = value;
            }
        }

        public Product2(String name, Decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public static List<Product2> GetSampleProducts()
        {
            List<Product2> products = new List<Product2>();
            products.Add(new Product2("West side story", 9.99m));
            products.Add(new Product2("Assassins", 19.99m));
            products.Add(new Product2("Frog", 29.99m));
            products.Add(new Product2("Sweeney Todd", 69.99m));
            return products;
        }

        public override string ToString()
        {
            //return base.ToString();
            return String.Format("{0} : {1}", name, price);
        }

    }


    /// <summary>
    ///  The Product Type -C# 3
    ///  Automatically implemented properties and  simplified initialization in C# 3
    /// </summary>
    class Product3
    {
        public String Name { get; private set; }

        public Decimal Price { get; private set; }

        public Product3(String name, Decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public Product3()
        {
            // TODO: Complete member initialization
        }

        public static List<Product3> GetSampleProducts()
        {
            return new List<Product3>
            { 
            new Product3{Name="West side story", Price= 9.99m},
            new Product3{Name="Assassins",Price= 19.99m},
            new Product3{Name="Frog", Price= 29.99m},
            new Product3{Name="Sweeney Todd",Price= 69.99m}
            };


        }

        public override string ToString()
        {
            //return base.ToString();
            return String.Format("{0} : {1}", Name, Price);
        }

    }

    /// <summary>
    ///  The Product Type -C# 4
    ///  Named arguments in C# 4  and making fully immutable again
    ///  This Class has basically the other features as well for demonstration
    /// </summary>
    class Product4
    {
        readonly String name;
        public String Name { get { return name; } }

        readonly Decimal price;
        public Decimal Price { get { return price; } }

        public Product4(String name, Decimal price)
        {
            this.name = name;
            this.price = price;
        }

        public Product4()
        {
            // TODO: Complete member initialization
        }

        public static List<Product4> GetSampleProducts()
        {
            return new List<Product4>
            { 
           new Product4( name: "West Side Story", price: 9.99m),
                    new Product4( name: "Assassins", price: 14.99m),
                    new Product4( name: "Frogs", price: 13.99m),
                    new Product4( name: "Sweeney Todd", price: 10.99m)
            };


        }

        #region Querying XML
        public static IEnumerable QueryXMLData() 
        {

            XDocument xdoc = XDocument.Parse(Properties.Resources.Data);
            var filteredXml = from p in xdoc.Descendants("Product")
                              join s in xdoc.Descendants("Supplier")
                              on (Int32)p.Attribute("SupplierID") equals (Int32)s.Attribute("SupplierID")
                              where (Decimal)p.Attribute("Price") > 10
                              select new
                              {
                                  SupplierName = (String)s.Attribute("Name"),
                                  ProductName = (String)p.Attribute("Name")
                              };

            foreach (var data in filteredXml) 
            {
                Console.WriteLine("ProductName: {0}, SupplierName:{1}", data.ProductName, data.SupplierName);
            }

            return filteredXml;
        }
        #endregion


        #region COM interoperability

        public static void SaveDataToExcel()
        {
           
            var app = new Application { Visible = false };
            Workbook workbook = app.Workbooks.Add();
            Worksheet workSheet = app.ActiveSheet;
            int row = 1;
            foreach (var product in Product4.GetSampleProducts().Where(p => p.Price != null)) 
            {
                workSheet.Cells[row, 1].Value = product.Name;
                workSheet.Cells[row, 2].Value = product.Price;
                row++;

            }
            workbook.SaveAs(Filename: "Demo.xls", FileFormat: XlFileFormat.xlWorkbookNormal);
            app.Application.Quit();

            
        }

        #endregion


        //#region Asynchronous code

        //private async void CheckProduct(object sender, EventArgs e) 
        //{
        //    try {
        //        String Id = "12334";
        //        Task<Product4> productLookUp = directory

        //    }
        //    catch (Exception e) { }

        //}


        //#endregion

        public override string ToString()
        {
            //return base.ToString();
            return String.Format("{0} : {1}", Name, Price);
        }

    }

    #endregion

    #region Sorting and Searching
    public class ProductComparer : IComparer ,IComparer<Product4>
    {
        public Int32 Compare(object x, object y) 
        {
            Product p1 = x as Product;
            Product p2 = y as Product;
            return p1.Name.CompareTo(p2.Name);
        }

         Int32 IComparer<Product4>.Compare(Product4 first, Product4 second) 
        {
            return first.Name.CompareTo(second.Name);
        }
    }

    
    #endregion
}
