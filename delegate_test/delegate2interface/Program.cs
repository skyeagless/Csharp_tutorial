using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///_06使用接口代替委托,接口可以先理解成抽象类
/// </summary>
namespace delegate2interface
{
    class Program
    {
        static void Main(string[] args)
        {
            //直接建立工厂
            IProductFactory pizzaFactory = new PizzaFactory();
            IProductFactory toycarFactory = new ToyCarFactory();
            //包装工厂
            WrapFactory wrapFactory = new WrapFactory();
            //完成包装,返回值是Box
            Box box1 = wrapFactory.wrapProduct(pizzaFactory);
            Box box2 = wrapFactory.wrapProduct(toycarFactory);

            Console.WriteLine(box1.Product.Name);
            Console.WriteLine(box2.Product.Name);

        }
    }


    //产品类
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    interface IProductFactory
    {
        Product Make();
    }

    class PizzaFactory : IProductFactory
    {
        //实现make方法
        public Product Make()
        {
            Product product = new Product();
            product.Name = "pizza";
            product.Price = 12;
            return product;
        } 
    }

    class ToyCarFactory : IProductFactory
    {
        public Product Make()
        {
            Product product = new Product();
            product.Name = "toycar";
            product.Price = 52;
            return product;
        }  
    }


    //包装类
    class Box
    {
        public Product Product { get; set; }
    }

    //包装工厂,使用接口参数
    class WrapFactory
    {
        public Box wrapProduct(IProductFactory productFactory)
        {
            Box box = new Box();
            Product product = productFactory.Make();
            box.Product = product;
            return box;
        }
    }

}


