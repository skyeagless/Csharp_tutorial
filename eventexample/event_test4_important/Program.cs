using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//事件拥有者是响应者的字段成员
namespace event_test4_important
{
    class Program
    {
        static void Main(string[] args)
        {
            MyForm form = new MyForm();
            form.ShowDialog();
        }
    }

    class MyForm : Form //form作为响应者，里面有响应处理器
    {
        private TextBox textBox;
        private Button button;//拥有者，能发生响应

        public MyForm()
        {
            this.textBox = new TextBox();
            this.button = new Button();
            this.Controls.Add(this.button);
            this.Controls.Add(this.textBox);//form上附加上textBox,button

            this.button.Text = "say 666";
            this.button.Click += this.ButtonClicked;
            this.button.Top = 100;
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            this.textBox.Text = "6666";
        }
    }
}
