using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hello_generic
{
    class Program
    {
        static void Main(string[] args)
        {
            //IList<int> list = new List<int>();
            //for(int i = 0; i < 100; i++)
            //{
            //    list.Add(i);
            //}
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}


            //IDictionary<int, string> dict = new Dictionary<int, string>();
            //dict[1] = "Tim";
            //dict[2] = "Tom";
            //Console.WriteLine("Student #1 is {0},Student #2 is {1}",dict[1],dict[2]);


            //泛型委托，经常被用于LINQ查询
            //Action<string> a1 = Say;
            //a1.Invoke("666");

            //Action<int> a2 = Mul;
            //a2.Invoke(6);
            Func<int, int, int> func1 = Add;
            Console.WriteLine(func1.Invoke(3, 6));
            //lamda表达式
            Func<double, double, double> func2 = (a, b) => { return a + b; };
            Console.WriteLine(func2.Invoke(3.7, 6.2));
        }

        static void Say(string str)
        {
            Console.WriteLine("Hello,{0}", str);
        }

        static void Mul(int x)
        {
            Console.WriteLine(x * 100) ;
        }

        static int Add(int a,int b)
        {
            return a + b;
        }

 
    }
}
