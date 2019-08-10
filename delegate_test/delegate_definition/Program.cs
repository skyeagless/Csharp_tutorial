using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegate_definition
{

    class Program
    {
        //自定义委托类型
        //一般情况下都不需要使用自定义委托类型，都是采用无返回值的Action或有参数有返回值的Func<T>
        public delegate double Calc(double x, double y);

        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            //委托也是一个类类型
            Calc calc1 = new Calc(calculator.Add);
            Calc calc2 = new Calc(calculator.Sub);

            double a = 100;
            double b = 200;
            double c = 0;

            c = calc1(a, b);
            Console.WriteLine(c) ;
            c = calc2.Invoke(a, b);
            Console.WriteLine(c);
        }
    }

    class Calculator
    {
        public double Add(double x,double y)
        {
            return x + y;
        }
        public double Sub(double x,double y)
        {
            return x - y;
        }
    }
}
