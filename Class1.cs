using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_Class
{
    public class Calculator
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
            }*/
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
    }
}
