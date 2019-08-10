using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//自定义点菜事件,事件的触发要在事件拥有者里面
namespace event_zidingyi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Customer customer = new Customer();
            Waiter waiter = new Waiter();
            customer.Order += waiter.Action;
            customer.Action();
            customer.PaytheBill();
        }
    }
    public class Customer
    {
        //先声明一个委托类型
        public delegate void OrderEventHandler(Customer customer, OrderEventArgs e);
        //但并不是委托字段,事件简化声明，包裹委托类型字段ordereventhandler
        public event OrderEventHandler Order;


        public double Bill { get; set; }
        public void PaytheBill()
        {
            Console.WriteLine("I will pay {0}", this.Bill);
        }
        
        public void Walkin()
        {
            Console.WriteLine("walk into the restaurant");
        }
        public void SitDown()
        {
            Console.WriteLine("Sit Down");
        }
        public void Think()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Let me think");
                Thread.Sleep(1000);
            }
            this.OnOrder("fish", "large");
        }
   
        public void Action()
        {
            this.Walkin();
            this.SitDown();
            this.Think();
        }

        //触发事件,访问级别必须为protected
        protected void OnOrder(string dishName, string size)
        {
            if (this.Order != null)
            {
                OrderEventArgs e = new OrderEventArgs();
                e.dishName = dishName;
                e.size = size;
                this.Order.Invoke(this, e);
            }
        }


    }



    public class OrderEventArgs : EventArgs
    {
        public string dishName { get; set; }
        public string size { get; set; }
    }

    //事件响应者
    public class Waiter
    {
        //事件处理器
        public void Action(Customer customer, OrderEventArgs e)
        {
            Console.WriteLine("I will serve you the dish -{0}", e.dishName);
            double price = 10;
            switch (e.size)
            {
                case "small":
                    price = price * 0.5; break;
                case "large":
                    price = price * 1.5; break;
                default:
                    break;
            }
            customer.Bill += price;
        }
    }



}
