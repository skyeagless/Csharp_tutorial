using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncTest
{
    class Program
    {
        static int num = 0;
        static void Main(string[] args)
        {
            //使用匿名函数,里面的都是形参
            Func<int,bool> CanEnd = (n) => n >= 5;
            Action<string> Method = (s) => { num += 1; Console.WriteLine(s); };
            Action<string,string> EndMethod = (s1,s2) => { Console.WriteLine(s1+s2); };
            StartYourShow(CanEnd,Method,EndMethod);
        }

        //不终止条件--循环事件--终止后事件
        static void StartYourShow(Func<int,bool> CanEnd,Action<string> Method,Action<string,string> EndMethod)
        {
            while (!CanEnd(num))
            {
                Method(DateTime.Now.TimeOfDay.ToString());
            }
            EndMethod("show","end");    
        }

    }
}
