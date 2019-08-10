using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace event_test3
{
    class Program
    {
        static void Main(string[] args)
        {
            MyFrom form = new MyFrom();
            form.Click += form.FormClicked;
            form.ShowDialog();
            Console.ReadKey();
        }
    }

    class MyFrom : Form
    {
        internal void FormClicked(object sender, EventArgs e)
        {
            this.Text = DateTime.Now.ToString();
        }
    }
}
