using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace combine
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDele<double> dele = new MyDele<double>(mul);
            Console.WriteLine(dele(2.2,3.2));
        }

     
    }

    delegate T MyDele<T>(T a, T b);
}
