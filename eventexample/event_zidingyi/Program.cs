using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//自定义点菜事件
namespace event_zidingyi
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Waiter waiter = new Waiter();
            customer.Order += waiter.Action;
            customer.Action();
            customer.PaytheBill();
        }
    }
    public class Customer {
        public double Bill { get; set; }
        //委托字段
        private OrderEventHandler OrderEventHandler;
        public void PaytheBill()
        {
            Console.WriteLine("I will pay {0}", this.Bill);
        }
        //声明点菜事件
        public event OrderEventHandler Order
        {
            add
            {
                this.OrderEventHandler += value;
            }
            remove
            {
                this.OrderEventHandler -= value;
            }
        } 
        //触发事件
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
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("Let me think");
                Thread.Sleep(1000);
            }
            if (this.OrderEventHandler!=null)
            {
                OrderEventArgs e = new OrderEventArgs();
                e.dishName = "kongpao chicken";
                e.size = "large";
                this.OrderEventHandler.Invoke(this, e);
            }
        }

        public void Action()
        {
            Console.WriteLine();
            this.Walkin();
            this.SitDown();
            this.Think();
        }
        
    }

    public class OrderEventArgs: EventArgs
    {
        public string dishName { get; set; }
        public string size { get; set; }
    }

    //先声明一个委托类型
    public delegate void OrderEventHandler(Customer customer, OrderEventArgs e);

    //事件响应者
    public class Waiter
    {
        //事件处理器
        public void Action(Customer customer, OrderEventArgs e)
        {
            Console.WriteLine("I will serve you the dish -{0}",e.dishName);
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
