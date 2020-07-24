using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace linked_list
{
    
    public partial class Form1 : Form
    {
        public static int N = 1;
        public static Node head = new Node();
        public static Node tail = new Node();
        public Form1()
        {
            head.next = tail;
            head.prev = head;
            tail.next = tail;
            tail.prev = head;
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            head.Insert(Convert.ToInt32(IndexNum.Text), Input.Text);
            Output.AppendText(head.Display());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            head.Remove(Convert.ToInt32(IndexNum.Text));
            Output.AppendText(head.Display());
        }
    }
    public class Node
    {
        public object data;
        public Node next;
        public Node prev;

        public void Insert(int index, object input)
        {
            if (index <= Form1.N && index > 0)
            {
                Node node = new Node();
                Node cur = Form1.head;
                for (int i = 0; i < index; i++)
                {
                    cur = cur.next;
                }
                node.data = input;
                node.next = cur;
                cur.prev.next = node;
                node.prev = cur.prev;
                cur.prev = node;
                Form1.N++;
            }
            else
            {
                MessageBox.Show("인덱스 값이 잘 못되었습니다. 리스트 수에 맞는 값을 입력해주세요");
            }
        }
        public void Remove(int index)
        {
            if (index < Form1.N && index > 0)
            {
                Node delete = Form1.head;
                for (int i = 0; i < index; i++)
                {
                    delete = delete.next;
                }
                delete.next.prev = delete.prev;
                delete.prev.next = delete.next;
                Form1.N--;
            }
            else
            {
                MessageBox.Show("인덱스 값이 잘 못되었습니다. 리스트 수에 맞는 값을 입력해주세요");
            }
        }
        public string Display()
        {
            string output = "현재 리스트는 ";
            Node cur = Form1.head.next;
            for (int i = 0; i < Form1.N-1; i++)
            {
                output = output + (cur.data).ToString() + ", ";
                cur = cur.next;
            }
            output = output + " 입니다. \r\n";
            return output;
        }

    }

}
