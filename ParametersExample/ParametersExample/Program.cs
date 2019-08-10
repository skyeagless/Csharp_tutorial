using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametersExample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> myList = new List<int>() { 11, 12, 13, 14, 15 };
            bool result = myList.All(x => x > 10);
            Console.WriteLine(result);
        }
        //static void Main(string[] args)
        //{
        //    double x = 3.14159;
        //    double y = x.Round(4);
        //    Console.WriteLine(y);
        //}
        static bool AllGreaterThanTen(List<int> intList)
        {
            foreach (var item in intList)
            {
                if (item <= 10)
                    return false;
            }
            return true;
        }

    }

    //static class DoubleExtension
    //{
    //    public static double Round(this double input,int digits)
    //    {
    //        double result = Math.Round(input, digits);
    //        return result;
    //    }
    //}
}
