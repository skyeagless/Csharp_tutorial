using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//接口的低耦合,有替换的地方使用，功能的提供方可替换
namespace interface_test2
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new PhoneUser(new HuaweiPhone());
            user.UsePhone();
        }
    }

    interface Iphone
    {
        void Dail();
        void Pickup();
        void Send();
        void Receive();
    }

    class NokiaPhone : Iphone
    {
        public void Dail()
        {
            Console.WriteLine("calling");
        }

        public void Pickup()
        {
            Console.WriteLine("Hello");
        }

        public void Receive()
        {
            Console.WriteLine("receive!");
        }

        public void Send()
        {
            Console.WriteLine("send");
        }
    }

    class HuaweiPhone : Iphone
    {
        public void Dail()
        {
            Console.WriteLine("calling");
        }

        public void Pickup()
        {
            Console.WriteLine("Hello");
        }

        public void Receive()
        {
            Console.WriteLine("huawei receive!");
        }

        public void Send()
        {
            Console.WriteLine("huawei " +
                "send");
        }
    }

    class PhoneUser
    {
        //接口类型的变量
        private Iphone _phone;
        public PhoneUser(Iphone phone)
        {
            _phone = phone;
        }
        public void UsePhone()
        {
            _phone.Dail();
            _phone.Pickup();
            _phone.Send();
            _phone.Receive();
        }
    }
}
