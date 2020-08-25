using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Bingo1
{
    public partial class Form1 : Form
    {
        List<int> list = new List<int>();
        DataTable dt = new DataTable();
        int[] arr = new int[25];
        int a = 0;
        public bool Bingo = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            list = new List<int>();
            dt = new DataTable();
            arr = new int[25];
            int index;
            Random rd = new Random();
            Bingo = false;
            Button b = (Button)sender;
            a = Convert.ToInt32(b.Tag);
            for (int i = 0; i < 2* a * a; i++)
            {
                list.Add(i + 1);
            }
            for (int i = 0; i < a; i++)
            {
                dt.Columns.Add((i + 1) + "줄");
            }
            for (int i = 0; i < a*a; i++)
            {
                index = rd.Next(0, list.Count - 1);
                arr[i] = list[index];
                list.RemoveAt(index);
            }
            for (int i = 0; i < a*a; i += a)
            {
                switch (a)
                {
                    case 3:
                        dt.Rows.Add(arr[i+1], arr[i], arr[i + 2]);
                        break;
                    case 4:
                        dt.Rows.Add(arr[i+2], arr[i], arr[i + 3], arr[i + 1]);
                        break;
                    case 5:
                        dt.Rows.Add(arr[i], arr[i + 3], arr[i + 4], arr[i + 1], arr[i + 2]);
                        break;
                }
            }
            dataGridView1.DataSource = dt;
        }
        public void BingoCheck(int[,] ar)
        {
            int rowstack = 0;
            int columstack = 0;
            int crossstack = 0;
            for (int i = 0; i < a; i++)
            {
                if (ar[i, i] == 0 || ar[i, a - 1 - i] == 0)
                {
                    crossstack++;
                    if (crossstack == a)
                    {
                        Bingo = true;
                        if (textBox1.InvokeRequired)
                        {
                            textBox1.BeginInvoke(new Action(() =>
                            {
                                textBox1.Text = "빙고가 완성되었습니다.";
                            }));
                        }
                        break;
                    }
                }
                for (int j = 0; j < a; j++)
                {
                    if (ar[i, j] == 0)
                    {
                        rowstack++;
                        if (rowstack == a)
                        {
                            Bingo = true;
                            if (textBox1.InvokeRequired)
                            {
                                textBox1.BeginInvoke(new Action(() =>
                                {
                                    textBox1.Text = "빙고가 완성되었습니다.";
                                }));
                            }
                            break;
                        }
                    }
                    if (ar[j, i] == 0)
                    {
                        columstack++;
                        if (columstack == a)
                        {
                            Bingo = true;
                            if (textBox1.InvokeRequired)
                            {
                                textBox1.BeginInvoke(new Action(() =>
                                {
                                    textBox1.Text = "빙고가 완성되었습니다.";
                                }));
                            }
                            break;
                        }
                    }
                }
                crossstack = 0;
                rowstack = 0;
                columstack = 0;
            }
        }
        public void Run()
        {
            list.Clear();
            int num;
            int[,] ar = new int[a,a];
            Random rd = new Random();
            for (int i = 0; i < 2 * a * a; i++)
            {
                list.Add(i + 1);
            }
            while (!Bingo)
            {
                num = rd.Next(0, list.Count-1);
                int c= list[num];
                int b = 0;
                Thread.Sleep(1000);
                if (textBox1.InvokeRequired)
                {
                    textBox1.BeginInvoke(new Action(() =>
                    {
                        textBox1.Text = "빙고 숫자는 " + c + "입니다.";
                    }));
                }
                foreach (DataRow row in dt.Rows)
                {
                    for (int i = 0; i < a; i++)
                    {
                        if (Convert.ToInt32(row[i]) == c)
                        {
                            row[i] = "0";
                        }
                        ar[b, i] = Convert.ToInt32(row[i]);
                    }
                    b++;
                }
                list.RemoveAt(num);
                BingoCheck(ar);
            }
        }
        private void BTN_Start_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(Run);
            t.Start();
        }
    }
}
