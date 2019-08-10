using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace eventexample
{
    class Program
    {
        static void Main(string[] args)
        {
            //事件的拥有者timer
            Timer timer = new Timer();
            timer.Interval = 1000;
            Boy boy = new Boy();
            Girl girl = new Girl();
            //事件订阅
            timer.Elapsed += boy.Action;
            timer.Elapsed += girl.Action;
            timer.Start();//激发事件
            Console.ReadLine();
        }
    }

    //事件的响应者boy对象
    class Boy
    {
        internal void Action(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Jump!");
        }
    }

    class Girl
    {
        internal void Action(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Sing!");
        }
    }
}
