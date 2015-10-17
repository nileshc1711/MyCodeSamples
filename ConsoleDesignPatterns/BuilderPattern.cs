using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDesignPatterns
{
    public interface IBuilder
    {
        void BuildPart1();
        void BuildPart2();
        void BuildPart3();
        Product GetProduct();
    }

    public class ConcreteBuilder : IBuilder 
    {
        private Product _product = new Product();

        public void BuildPart1()
        {
            _product.Part1 = "Part 1";
        }

        public void BuildPart2()
        {
            _product.Part2 = "Part 2";
        }

        public void BuildPart3()
        {
            _product.Part3 = "Part 3";
        }

        public Product GetProduct() 
        {
            return _product;
        }
    }

    public class Product 
    {
        public string Part1 { get; set; }
        public string Part2 { get; set; }
        public string Part3 { get; set; }
    }

    public class Director 
    {
        public void Construct(IBuilder builder) 
        {
            builder.BuildPart1();
            builder.BuildPart2();
            builder.BuildPart3();

        }
    }
}
