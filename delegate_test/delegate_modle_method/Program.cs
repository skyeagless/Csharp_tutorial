using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  使用模板方法，可以提高代码的复用
/// 代码的复用不但可以提高工作效率，还可以减少bug的引入；
/// 良好的复用结构是所有优秀软件所追求的共同目标之一；
/// </summary>
namespace delegate_modle_method
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
            //完成包装,返回值是Box
            Box box1 = wrapFactory.wrapProduct(product1);
            Box box2 = wrapFactory.wrapProduct(product2);

            Console.WriteLine(box1.Product.Name);
            Console.WriteLine(box2.Product.Name);

        }
    }

    //产品类
    class Product
    {
        public string Name { get; set; }
    }
    //包装类
    class Box {
        public Product Product { get; set; }
    }

    //包装工厂
    class WrapFactory
    {
        public Box wrapProduct(Func<Product> getProduct)
        {
            Box box = new Box();
            Product product = getProduct.Invoke();
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
            return product;
        }

        public Product MakeToyCar()
        {
            Product product = new Product();
            product.Name = "toycar";
            return product;
        }
    }

}
