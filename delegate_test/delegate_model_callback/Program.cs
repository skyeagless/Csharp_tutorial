using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 工作中经常会用到Logger类型，其作用就是输出工作日志
/// 在对log进行记录的时候经常会使用委托回调方法
/// </summary>
namespace delegate_model_callback
{
    class Program
    {
        static void Main(string[] args)
        {
            //先建立生产工厂
            ProductFactory productFactory = new ProductFactory();
            //包装工厂
            WrapFactory wrapFactory = new WrapFactory();
            //模版委托的替换
            Func<Product> product1 = new Func<Product>(productFactory.MakePizza);
            Func<Product> product2 = new Func<Product>(productFactory.MakeToyCar);
            Logger logger = new Logger();
            Action<Product> log = new Action<Product>(logger.log);
            //完成包装,返回值是Box
            Box box1 = wrapFactory.wrapProduct(product1,log);
            Box box2 = wrapFactory.wrapProduct(product2,log);

            Console.WriteLine(box1.Product.Name);
            Console.WriteLine(box2.Product.Name);

        }
    }

    class Logger
    {
        public void log(Product product)
        {
            Console.WriteLine("Product {0} created, price is {1}",product.Name,product.Price);
        }
    }

    //产品类
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
    //包装类
    class Box
    {
        public Product Product { get; set; }
    }

    //包装工厂,多一个委托参数
    class WrapFactory
    {
        public Box wrapProduct(Func<Product> getProduct,Action<Product> logger_callback)
        {
            Box box = new Box();
            Product product = getProduct.Invoke();
            if (product.Price > 50)
                logger_callback.Invoke(product);

            box.Product = product;
            return box;
        }
    }

    //生产工厂，修补程序只需要增加这个就可以
    class ProductFactory
    {
        public Product MakePizza()
        {
            Product product = new Product();
            product.Name = "pizza";
            product.Price = 12;
            return product;
        }

        public Product MakeToyCar()
        {
            Product product = new Product();
            product.Name = "toycar";
            product.Price = 52;
            return product;
        }
    }

}
