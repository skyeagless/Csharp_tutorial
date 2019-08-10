using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//为做基类而生的"抽象类"与"开放/关闭原则",函数成员没有完全实现
namespace abstract_class
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle v = new Car();
            v.Run();
            v.Stop();
        }
    }

    //最基类,纯抽象类==接口
    //abstract class VehicleBase
    //{
    //    abstract public void Stop();
    //    abstract public void Run();
    //}
    interface IVehicleBase
    {
        void Stop();
        void Run();
    }

    abstract class Vehicle: IVehicleBase
    {
        //类实现接口
        public void Stop()
        {
            Console.WriteLine("stopped");
        }
        //下推抽象类
        abstract public void Run();
    }


    class Car:Vehicle{
        public override void Run()
        {
            Console.WriteLine("Car is running");
        }
    }
    class Truck:Vehicle
    {
        public override void Run()
        {
            Console.WriteLine("Truck is running");
        }
    }   
}
