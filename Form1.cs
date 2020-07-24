using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace queue
{
    public partial class Form1 : Form
    {
        Myqueue a = new Myqueue();
        public Form1()
        {
            InitializeComponent();
            Output.AppendText (a.Display());
        }

        private void BTN_Push_Click(object sender, EventArgs e)
        {
            a.push(Input.Text);
            Output.AppendText(a.Display());
        }

        private void BTN_Pop_Click(object sender, EventArgs e)
        {
            a.pop();
            Output.AppendText(a.Display());
        }
    }

    public class Myqueue
    {
        public Myqueue() { arr = new string[] { "0", "0", "0", "0", "0" }; stack = 0; }
        public string[] arr;
        public int stack;

        public void push(String Input)
        {
            if (arr[0] == "0") { arr[0] = Input; }
            else if (arr[1] == "0") { arr[1] = Input; }
            else if (arr[2] == "0") { arr[2] = Input; }
            else if (arr[3] == "0") { arr[3] = Input; }
            else if (arr[4] == "0") { arr[4] = Input; }
            else
            {
                MessageBox.Show("배열이 가득 찼습니다.");
            }
            stack = 0;
                for (int i = 0; i < arr.Length; i++) { if (arr[i] != "0") stack++; }
        }
        public void pop()
        {
            if (stack <= 0)
            {
                MessageBox.Show("삭제할 숫자가 없습니다.");
                stack = 0;
            }
            else
            {
                if (arr[0] != "0") {
                    for (int i = 0; i < 4; i++) { arr[i] = arr[i + 1];
                    }
                    arr[4] = "0";
                }
                else { MessageBox.Show("삭제할 숫자가 없습니다."); }
                stack = 0;
                for (int i = 0; i < 5; i++) { if (arr[i] != "0") stack++; }
            }
        }
        public string Display()
        {
            string output = "현재의 배열은 ";
            for (int i = 0; i < 4; i++)
            {
                output = output + arr[i] + ", ";
            }
            output = output + arr[4] + " 입니다. \r\n";
            return output;
        }
    }
}
