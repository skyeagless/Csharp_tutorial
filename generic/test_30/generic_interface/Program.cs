using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generic_interface
{
    class Program
    {
        static void Main(string[] args)
        {
            //Student<int> stu = new Student<int>();
            //stu.ID = 101;
            //stu.Name = "SkyEagle";
            //Student<ulong> student = new Student<ulong>();
            Student student = new Student();
            student.ID = 10000000;
            student.Name = "skyeagle";
        }
    }

    //ID类型不明,因此使用泛型接口
    interface IUnique<T>
    {
        T ID { get; set; }
    }

    //class Student<T> : IUnique<T>
    //{
    //    public T ID { get ; set; }
    //    public string Name { get; set; }
    //}

        //实现接口的时候直接特化了
    class Student : IUnique<ulong>
    {
        public ulong ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get; set; }
    }

}
