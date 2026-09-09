
using System;
using System.Collections.Generic;

namespace RefactoringGuru.DesignPatterns.Builder.Conceptual
{
    // It makes sense to use the Builder pattern only when your products are quite
    // complex and require extensive configuration.
    //
    // Unlike in other creational patterns, different concrete builders can produce
    // unrelated products. In other words, results of various builders may not
    // always follow the same interface.
    public class Product1
    {
        public List<string> Parts = new();

        public void ListParts()
        {
            Console.WriteLine("Product parts: ");
            for (int i = 0; i < Parts.Count; i++)
            {
                if (i == Parts.Count - 1)
                {
                    Console.WriteLine(Parts[i]);
                }
                else
                {
                    Console.WriteLine(Parts[i] + ", ");
                }
            }
            Console.WriteLine("\n");
        }
    }

    // The Builder interface specifies methods for creating the different parts of
    // the Product objects.
    public interface IBuilder
    {
        void ProducePartA();
        void ProducePartB();
        void ProducePartC();
    }

    // The Concrete Builder classes follow the Builder interface and provide
    // specific implementations of the building steps. Your program may have several
    // variations of Builders, implemented differently.
    public class ConcreteBuilder1 : IBuilder
    {
        private Product1 _product;

        // A fresh builder instance should contain a blank product object, which is
        // used in further assembly.
        public ConcreteBuilder1()
        {
            Reset();
        }

        public void Reset()
        {
            _product = new Product1();
        }

        // All production steps work with the same product instance.
        public void ProducePartA()
        {
            _product.Parts.Add("PartA1");
        }

        public void ProducePartB()
        {
            _product.Parts.Add("PartB1");
        }

        public void ProducePartC()
        {
            _product.Parts.Add("PartC1");
        }

        // Concrete Builders are supposed to provide their own methods for
        // retrieving results. That's because various types of builders may create
        // entirely different products that don't follow the same interface.
        // Therefore, such methods cannot be declared in the base Builder interface
        // (at least in a statically typed programming language).
        //
        // Usually, after returning the end result to the client, a builder instance
        // is expected to be ready to start producing another product. That's why
        // it's a usual practice to call the reset method at the end of the
        // `GetProduct` method body. However, this behavior is not mandatory, and
        // you can make your builders wait for an explicit reset call from the
        // client code before disposing of the previous result.
        public Product1 GetProduct()
        {
            Product1 result = _product;
            Reset();
            return result;
        }
    }

    // The Director is only responsible for executing the building steps in a
    // particular sequence. It is helpful when producing products according to a
    // specific order or configuration. Strictly speaking, the Director class is
    // optional, since the client can control builders directly.
    public class Director
    {
        private IBuilder _builder;

        // The Director works with any builder instance that the client code passes
        // to it. This way, the client code may alter the final type of the newly
        // assembled product.
        public void SetBuilder(IBuilder builder)
        {
            _builder = builder;
        }

        // The Director can construct several product variations using the same
        // building steps.
        public void BuildMinimalViableProduct()
        {
            _builder.ProducePartA();
        }

        public void BuildFullFeaturedProduct()
        {
            _builder.ProducePartA();
            _builder.ProducePartB();
            _builder.ProducePartC();
        }
    }

    // The client code creates a builder object, passes it to the director and then
    // initiates the construction process. The end result is retrieved from the
    // builder object.
    class Program
    {
        static void ClientCode(Director director)
        {
            ConcreteBuilder1 builder = new ConcreteBuilder1();
            director.SetBuilder(builder);
            Console.WriteLine("Standard basic product:\n");
            director.BuildMinimalViableProduct();

            Product1 p = builder.GetProduct();
            p.ListParts();

            Console.WriteLine("Standard full featured product:\n");
            director.BuildFullFeaturedProduct();

            p = builder.GetProduct();
            p.ListParts();

            // Remember, the Builder pattern can be used without a Director class.
            Console.WriteLine("Custom product:\n");
            builder.ProducePartA();
            builder.ProducePartC();
            p = builder.GetProduct();
            p.ListParts();
        }

        static void Main(string[] args)
        {
            var director = new Director();
            ClientCode(director);
        }
    }
}
