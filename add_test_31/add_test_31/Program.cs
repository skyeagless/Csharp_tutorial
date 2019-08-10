using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace add_test_31
{
    class Program
    {
        static void Main(string[] args)
        {
            //静态方法委托
            MyDele dele1 = new MyDele(M1);
            Student stu = new Student();
            //实例方法委托
            dele1 += stu.SayHello;
            dele1.Invoke();
        }

        //静态方法
        static void M1()
        {
            Console.WriteLine("666");
        }
    }

    //委托也是一种类
    delegate void MyDele();
    class Student
    {
        //实例方法
        public void SayHello()
        {
            Console.WriteLine("Hello");
        }
    }

    
}
