using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator_Class;

namespace Calculator_Ver5
{
    public partial class Form1 : Form
    {
        Calculator a = new Calculator();
        public Form1()
        {
            InitializeComponent();
        }
        private void BTN_Calc_Click(object sender, EventArgs e)
        {
            if (a.isresult == true)
            {
                a.recentNum = a.savedNum;
                if(a.isbinary == true)
                {
                    a.Input = Convert.ToString(Convert.ToInt32(a.recentNum), 2);
                }
                if (a.isdecimal == true)
                {
                    a.Input = Convert.ToString(a.recentNum);
                }
                if (a.ishexadecimal == true)
                {
                    a.Input = string.Format("{0:X}", (Convert.ToInt32(a.recentNum))); ;
                }
                Output.Text = a.Input;
                a.isresult = false;
            }
            if (a.Iscalc == true)
            {
                return;
            }
            Button b = (Button)sender;
            switch (b.Text)
            {
                case "+":
                    a.Plus();
                    store.Text = "";
                    foreach (string a in a.list)
                    {
                        store.AppendText(a);
                    }
                    break;
                case "-":
                    a.Minus();
                    store.Text = "";
                    foreach (string a in a.list)
                    {
                        store.AppendText(a);
                    }
                    break;
                case "X":
                    a.Multi();
                    store.Text = "";
                    foreach (string a in a.list)
                    {
                        store.AppendText(a);
                    }
                    break;
                case "÷":
                    a.Div();
                    store.Text = "";
                    foreach (string a in a.list)
                    {
                        store.AppendText(a);
                    }
                    break;
            }
            a.Iscalc = true;
            //Output.Text = Convert.ToString(recentNum);
            a.count++;
            a.sqr_ = 0;
            a.pointNum = 0;
            a.isParen_C = false;
        }
        private void BTN_Num_Click(object sender, EventArgs e)
        {
            if(a.isParen_C == true)
            {
                return;
            }
            if (a.isresult == true)
            {
                a.Clear();
                store.Text = "";
                Output.Text = "0";
            }
            if (Output.Text == "0" || a.Iscalc == true)
            {
                a.Input = "";
                a.Iscalc = false;
            }
            if (a.sqr_ > 0)
            {
                a.recentNum = 0;
                a.Input = "";
                a.sqr_ = 0;
            }
            /*if (Ispercent == true)
            {
                recentNum = 0;
                Input = "";
                Ispercent = false;
                list.RemoveAt(list.Count - 1);
            }*/
            Button b = (Button)sender;
            a.Input = a.Input + b.Text;
            if (a.Input == "") { a.Input = "0"; }
            Output.Text = a.Input;
            if (a.isdecimal == true)
            {
                a.recentNum = Convert.ToDouble(a.Input);
            }
            if (a.isbinary == true)
            {
                a.recentNum = Convert.ToDouble(Convert.ToInt32(a.Input,2));
            }
            if (a.ishexadecimal == true)
            {
                a.recentNum = Convert.ToDouble(Convert.ToInt32(a.Input, 16));
            }
        }
        private void BTN_Sign_Click(object sender, EventArgs e)
        {
            if (a.Input == "0")
            {
                return;
            }
            else
            {
                a.recentNum = -a.recentNum;
                a.Input = Convert.ToString(a.recentNum);
            }
            Output.Text = a.Input;
        }
        private void BTN_Result_Click_1(object sender, EventArgs e)
        {
            if(a.isresult == true)
            {
                return;
            }
            if (a.Paren_C != a.Paren_O)
            {
                MessageBox.Show("수식이 정확한지 확인해주세요");
                return;
            }
            if (a.list.Last() == " + " || a.list.Last() == " - " || a.list.Last() == " X " || a.list.Last() == " ÷ ")
            {
                if (a.Input == "")
                {
                    return;
                }
                a.list.Add(a.Input);
            }
            /*if (list.Count % 2 == 0)
            {
                return;
            }*/
            store.Text = "";
            foreach (string a in a.list)
            {
                store.AppendText(a);
            }
            store.AppendText(" = ");
            if (a.isbinary == true)
            {
                List<int> iBase10 = new List<int>();
                for(int i = 0; i < a.list.Count; i++)
                {
                    if (a.list[i] != " + " && a.list[i] != " - " && a.list[i] != " X " && a.list[i] != " ÷ " && a.list[i] != "(" && a.list[i] != ")") 
                    {
                        iBase10.Add(Convert.ToInt32(a.list[i], 2));
                    }
                }
                for (int i = 0; i < a.list.Count; i++)
                {
                    if(a.list[i] != " + " && a.list[i] != " - " && a.list[i] != " X " && a.list[i] != " ÷ " && a.list[i] != "(" && a.list[i] != ")")
                    {
                        a.list[i] = Convert.ToString(iBase10[0]);
                        iBase10.RemoveAt(0);
                    }
                }
            }
            if (a.ishexadecimal == true)
            {
                List<int> iBase10 = new List<int>();
                for (int i = 0; i < a.list.Count; i++)
                {
                    if (a.list[i] != " + " && a.list[i] != " - " && a.list[i] != " X " && a.list[i] != " ÷ " && a.list[i] != "(" && a.list[i] != ")")
                    {
                        iBase10.Add(Convert.ToInt32(a.list[i], 16));
                    }
                }
                for (int i = 0; i < a.list.Count; i++)
                {
                    if (a.list[i] != " + " && a.list[i] != " - " && a.list[i] != " X " && a.list[i] != " ÷ " && a.list[i] != "(" && a.list[i] != ")")
                    {
                        a.list[i] = Convert.ToString(iBase10[0]);
                        iBase10.RemoveAt(0);
                    }
                }
            }
            a.Convert_to_postfix();
            /*Output.Text = "";
            foreach(string a in listExp)
            {
                Output.AppendText(a);
            }*/
            a.calculate();
            a.Input = "";
            if (a.isbinary == true)
            {
                Output.Text = Convert.ToString(Convert.ToInt32(a.savedNum), 2);
            }
            if (a.ishexadecimal == true)
            {
                Output.Text = Convert.ToString(Convert.ToInt32(a.savedNum), 16);
            }
            if (a.isdecimal == true)
            {
                Output.Text = Convert.ToString(a.savedNum);
            }
            a.recentNum = a.savedNum;
            a.isresult = true;
            a.list.Clear();
            a.Iscalc = false;
            a.pointNum = 0;
            a.Paren_O = 0;
            a.Paren_C = 0;
        }
        private void BTN_Point_Click(object sender, EventArgs e)
        {
            if (a.pointNum == 0)
            {
                if (a.Input == "" || a.isresult == true)
                {
                    a.Input = "0";
                    a.isresult = false;
                }
                a.Input = a.Input + ".";
                Output.Text = a.Input;
                a.pointNum++;
            }
            else { return; }
        }
        private void BTN_Clear_Click(object sender, EventArgs e)
        {
            a.Clear();
            store.Text = "";
            Output.Text = "0";
        }
        private void BTN_Remove_Click(object sender, EventArgs e)
        {
            if (a.Ispercent == true)
            {
                return;
            }
            if (a.sqr_ > 0)
            {
                return;
            }
            if (a.Input.Length == 0)
            {
                return;
            }
            else
            {
                if (a.Input.Length == 1)
                {
                    a.Input = "";
                }
                else
                {
                    a.Input = a.Input.Remove(a.Input.Length - 1);
                }
            }
            if (a.Input == "")
            {
                a.recentNum = 0;
            }
            else
            {
                a.recentNum = Convert.ToDouble(a.Input);
            }
            if (a.Input == "")
            {
                Output.Text = "0";
            }
            else
            {
                Output.Text = a.Input;
            }
        }
        private void BTN_ClearRece_Click(object sender, EventArgs e)
        {
            if (a.isresult == true) { a.savedNum = 0; }
            a.Input = "";
            Output.Text = "0";
            a.recentNum = 0;
            a.pointNum = 0;
            a.Ispercent = false;
            a.sqr_ = 0;
            a.isresult = false;
        }
        private void BTN_Square_Click(object sender, EventArgs e)
        {
            if (a.Input == "") { a.Input = "0"; }
            a.recentNum = Math.Pow(a.recentNum, 2);
            a.Input = Convert.ToString(a.recentNum);
            //list.Add(Input);
            Output.Text = a.Input;
            store.Text = "";
            foreach (string a in a.list)
            {
                store.AppendText(a);
            }
            a.sqr_++;
        }
        private void BTN_Root_Click(object sender, EventArgs e)
        {
            if (a.Input == "") { a.Input = "0"; }
            a.recentNum = Math.Sqrt(a.recentNum);
            a.Input = Convert.ToString(a.recentNum);
            //list.Add(Input);
            Output.Text = a.Input;
            store.Text = "";
            foreach (string a in a.list)
            {
                store.AppendText(a);
            }
            a.sqr_++;
        }
        private void BTN_Inverse_Click(object sender, EventArgs e)
        {
            if (a.Input == "") { a.Input = "0"; }
            a.recentNum = 1 / a.recentNum;
            a.Input = Convert.ToString(a.recentNum);
            //list.Add(Input);
            Output.Text = a.Input;
            store.Text = "";
            foreach (string a in a.list)
            {
                store.AppendText(a);
            }
            a.sqr_++;
        }
        private void BTN_Percent_Click(object sender, EventArgs e)
        {
            if (a.Iscalc == true)
            {
                return;
            }
            a.recentNum = (a.recentNum / 100);
            a.Input = Convert.ToString(a.recentNum);
            a.list.Add(a.Input);
            a.Ispercent = true;
            Output.Text = a.Input;
            store.Text = "";
            foreach (string a in a.list)
            {
                store.AppendText(a);
            }
        }
        private void BTN_Parenthesis_Open_Click(object sender, EventArgs e)
        {
            if (a.Iscalc == false && a.list.Count != 0)
            {
                return;
            }
            if (a.isresult == true)
            {
                a.Clear();
                store.Text = "";
                Output.Text = "0";
            }
            a.list.Add("(");
            a.Paren_O++;
            a.Input = "";
            store.Text = "";
            foreach (string a in a.list)
            {
                store.AppendText(a);
            }
            Output.Text = Convert.ToString(a.savedNum);
        }
        private void BTN_Parenthesis_Close_Click(object sender, EventArgs e)
        {
            if (a.Iscalc == true || a.Paren_C >= a.Paren_O)
            {
                return;
            }
            if (a.isresult == true)
            {
                a.Clear();
                store.Text = "";
                Output.Text = "0";
            }
            a.list.Add(a.Input);
            a.list.Add(")");
            a.Paren_C++;
            a.isParen_C = true;
            a.Input = "";
            store.Text = "";
            foreach (string a in a.list)
            {
                store.AppendText(a);
            }
            Output.Text = Convert.ToString(a.savedNum);
        }
        private void BTN_Binary_Click(object sender, EventArgs e)
        {
            if (a.savedNum != (int)a.savedNum || a.recentNum !=(int)a.recentNum)
            {
                MessageBox.Show("소수값은 변환할 수 없습니다.");
                return;
            }
            if (a.isdecimal == true)
            {
                if (Output.Text != "0")
                {
                    a.Input = Convert.ToString(Convert.ToInt32(Output.Text), 2);
                    Output.Text = a.Input;
                    store.Text = "";
                }
            }
            if (a.ishexadecimal == true)
            {
                if (Output.Text != "0")
                {
                    a.Input = Convert.ToString(Convert.ToInt32(Output.Text, 16), 2);
                    Output.Text = a.Input;
                    store.Text = "";
                }
            }
            a.isdecimal = false;
            a.isbinary = true;
            a.ishexadecimal = false;
            BTN_2.Enabled = false;
            BTN_3.Enabled = false;
            BTN_4.Enabled = false;
            BTN_5.Enabled = false;
            BTN_6.Enabled = false;
            BTN_7.Enabled = false;
            BTN_8.Enabled = false;
            BTN_9.Enabled = false;
            BTN_A.Enabled = false;
            BTN_B.Enabled = false;
            BTN_C.Enabled = false;
            BTN_D.Enabled = false;
            BTN_E.Enabled = false;
            BTN_F.Enabled = false;
            BTN_Point.Enabled = false;
            BTN_Percent.Enabled = false;
            BTN_Inverse.Enabled = false;
            BTN_Root.Enabled = false;
            BTN_Square.Enabled = false;
            BTN_Decimal.Enabled = true;
            BTN_Binary.Enabled = false;
            BTN_Hexadecimal.Enabled = true;
        }
        private void BTN_Hexadecimal_Click(object sender, EventArgs e)
        {
            if (a.savedNum != (int)a.savedNum || a.recentNum != (int)a.recentNum)
            {
                MessageBox.Show("소수값은 변환할 수 없습니다.");
                return;
            }
            if (a.isdecimal == true)
            {
                if (Output.Text != "0")
                {
                    a.Input = string.Format("{0:X}", (Convert.ToInt32(Output.Text)));
                    Output.Text = a.Input;
                    store.Text = "";
                }
            }
            if (a.isbinary == true)
            {
                if (Output.Text != "0")
                {
                    a.Input = string.Format("{0:X}",(Convert.ToInt32(Output.Text,2)));
                    Output.Text = a.Input;
                    store.Text = "";
                }
            }
            a.isdecimal = false;
            a.isbinary = false;
            a.ishexadecimal = true;
            BTN_2.Enabled = true;
            BTN_3.Enabled = true;
            BTN_4.Enabled = true;
            BTN_5.Enabled = true;
            BTN_6.Enabled = true;
            BTN_7.Enabled = true;
            BTN_8.Enabled = true;
            BTN_9.Enabled = true;
            BTN_A.Enabled = true;
            BTN_B.Enabled = true;
            BTN_C.Enabled = true;
            BTN_D.Enabled = true;
            BTN_E.Enabled = true;
            BTN_F.Enabled = true;
            BTN_Point.Enabled = false;
            BTN_Percent.Enabled = false;
            BTN_Inverse.Enabled = false;
            BTN_Root.Enabled = false;
            BTN_Square.Enabled = false;
            BTN_Decimal.Enabled = true;
            BTN_Binary.Enabled = true;
            BTN_Hexadecimal.Enabled = false;
        }
        private void BTN_Decimal_Click(object sender, EventArgs e)
        {
            if(a.isbinary == true)
            {
                if (Output.Text != "0")
                {
                    a.Input = Convert.ToString(Convert.ToInt32(Output.Text,2));
                    Output.Text = a.Input;
                    store.Text = "";
                }
            }
            if (a.ishexadecimal == true)
            {
                if (Output.Text != "0")
                {
                    a.Input = Convert.ToString(Convert.ToInt32(Output.Text, 16));
                    Output.Text = a.Input;
                    store.Text = "";
                }
            }
            a.isdecimal = true;
            a.isbinary = false;
            a.ishexadecimal = false;
            BTN_2.Enabled = true;
            BTN_3.Enabled = true;
            BTN_4.Enabled = true;
            BTN_5.Enabled = true;
            BTN_6.Enabled = true;
            BTN_7.Enabled = true;
            BTN_8.Enabled = true;
            BTN_9.Enabled = true;
            BTN_A.Enabled = false;
            BTN_B.Enabled = false;
            BTN_C.Enabled = false;
            BTN_D.Enabled = false;
            BTN_E.Enabled = false;
            BTN_F.Enabled = false;
            BTN_Point.Enabled = true;
            BTN_Percent.Enabled = true;
            BTN_Inverse.Enabled = true;
            BTN_Root.Enabled = true;
            BTN_Square.Enabled = true;
            BTN_Decimal.Enabled = false;
            BTN_Binary.Enabled = true;
            BTN_Hexadecimal.Enabled = true;
        }
    }
    /*public class Calculator
    {
        public List<string> list = new List<string>();
        public List<string> listExp = new List<string>();
        public Stack<string> stack = new Stack<string>();
        public string Input = "";
        public int pointNum = 0;
        public double savedNum = 0;
        public double recentNum = 0;
        public int count = 0;
        public bool Iscalc = false;
        public bool Ispercent = false;
        public int sqr_ = 0;
        public bool isresult = false;
        public int Paren_O = 0;
        public int Paren_C = 0;
        public bool isdecimal = true;
        public bool isbinary = false;
        public bool ishexadecimal = false;
        public bool isParen_C = false;

        public void Plus()
        {
            /*if (list.Count % 2 == 0)
            {
                list.Add(Input);
                list.Add(" + ");
            }
            else
            {
                list.Add(" + ");
            }
            list.Add(Input);
            list.Add(" + ");
            Input = "";
        }
        public void Minus()
        {
            list.Add(Input);
            list.Add(" - ");
            Input = "";
        }
        public void Multi()
        {
            list.Add(Input);
            list.Add(" X ");
            Input = "";
        }
        public void Div()
        {
            list.Add(Input);
            list.Add(" ÷ ");
            Input = "";
        }
        public int Get_weight(string oper)
        {
            if (oper == " X " || oper == " ÷ ")
                return 3;
            else if (oper == " + " || oper == " - ")
                return 2;
            else if (oper == "(")
                return 1;
            else
                return -1;
        }
        public void Convert_to_postfix()
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == " + " || list[i] == " - " || list[i] == " X " || list[i] == " ÷ " || list[i] == "(" || list[i] == ")")
                {
                    if (stack.Count == 0 || list[i] == "(")
                    {
                        stack.Push(list[i]);
                    }
                    else if (list[i] == ")")
                    {
                        String op = stack.Pop();
                        while (op != "(")
                        {
                            listExp.Add(op);
                            op = stack.Pop();
                        }
                    }
                    else
                    {
                        if (Get_weight(list[i]) > Get_weight(stack.Peek()))
                        {
                            stack.Push(list[i]);
                        }
                        else
                        {
                            for (int j = 0; j < stack.Count; j++)
                            {
                                if (Get_weight(list[i]) <= Get_weight(stack.Peek()))
                                {
                                    listExp.Add(stack.Pop());
                                    j--;
                                }
                                else
                                {
                                    stack.Push(list[i]);
                                    break;
                                }
                            }
                            if (stack.Count == 0)
                            {
                                stack.Push(list[i]);
                            }
                        }
                    }
                }
                else
                {
                    listExp.Add(list[i]);
                }
            }
            while (stack.Count > 0)
                listExp.Add(stack.Pop());
        }
        public double clac(double num1, double num2, string oper)
        {
            switch (oper)
            {
                case " + ":
                    return num1 + num2;
                case " - ":
                    return num1 - num2;
                case " X ":
                    return num1 * num2;
                case " ÷ ":
                    return num1 / num2;
            }
            return 0;
        }
        public void calculate()
        {
            Stack<double> stack_ = new Stack<double>();
            foreach (string a in listExp)
            {
                if (a == " + " || a == " - " || a == " X " || a == " ÷ ")
                {
                    double Num2;
                    Num2 = stack_.Pop();
                    double Num1;
                    Num1 = stack_.Pop();
                    stack_.Push(clac(Num1, Num2, a));
                }
                else if (a == "") { }
                else
                {
                    stack_.Push(Convert.ToDouble(a));
                }
            }
            savedNum = stack_.Pop();
        }
        public void Clear()
        {
            Input = "";
            count = 0;
            list.Clear();
            pointNum = 0;
            savedNum = 0;
            recentNum = 0;
            Input = "";
            Iscalc = true;
            Ispercent = false;
            isresult = false;
            isParen_C = false;
            sqr_ = 0;
            Paren_O = 0;
            Paren_C = 0;
        }
    }*/
}
