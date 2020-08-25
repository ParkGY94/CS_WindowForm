using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Serial
{
    public partial class Form1 : Form
    {
        SerialPort_FUNC sp = new SerialPort_FUNC();
        /*public delegate void Ctr_Control(Control ctr, string text);
        public void SettextControl(Control ctr, string text)
        {
            if (InvokeRequired)
            {
                Ctr_Control CI = new Ctr_Control(SettextControl);
                ctr.Invoke(CI, ctr, text);
            }
            else
            {
                ctr.Text = text;
            }
        }*/
        public Form1()
        {
            InitializeComponent();
            serialPort1.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.Write("TRG" + "\r\n");
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string a = serialPort1.ReadLine();
            //SettextControl(textBox1, a);
            if (InvokeRequired)
            {
                textBox1.BeginInvoke(new Action(() =>
                {
                    textBox1.AppendText(a + "\r\n");
                }));
            }
            else
                textBox1.AppendText("-1");
         }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Write("TMES" + "\r\n");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            serialPort1.Write("Reset" + "\r\n");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("HOLD " + sp.Hold_OnOff() + "\r\n");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            serialPort1.Write("FUNC " + sp.ModeChange() + "\r\n");
        }
        private void button6_Click(object sender, EventArgs e)
        {
            serialPort1.Write("AUTO " + sp.Auto_OnOff() + "\r\n");
        }
        private void button7_Click(object sender, EventArgs e)
        {
            serialPort1.Write("Hz " + sp.Frequency() + "\r\n");
        }
        private void button8_Click(object sender, EventArgs e)
        {
            serialPort1.Write("SMP " + sp.Sampling_Setting() + "\r\n");
        }
        private void button9_Click(object sender, EventArgs e)
        {
            serialPort1.Write("RNG " + sp.Range_Setting() + "\r\n");
        }
        private void button10_Click(object sender, EventArgs e)
        {
            serialPort1.Write("ADJ" + "\r\n");
        }
        private void button11_Click(object sender, EventArgs e)
        {
            serialPort1.Write("EOC" + "\r\n");
        }
        private void button12_Click(object sender, EventArgs e)
        {
            serialPort1.Write("RMES" + "\r\n");
        }
        private void button13_Click(object sender, EventArgs e)
        {
            serialPort1.Write("TC " + sp.Temperature() + "\r\n");
        }
        private void button14_Click(object sender, EventArgs e)
        {
            serialPort1.Write("COMP " + sp.Comparator() + "\r\n");
        }
        private void button15_Click(object sender, EventArgs e)
        {
            serialPort1.Write("CNO " + sp.Comparator_Table() + "\r\n");
        }
        private void button16_Click(object sender, EventArgs e)
        {
            serialPort1.Write("CMD " + sp.Comparator_Mode() + "\r\n");
        }
        private void button17_Click(object sender, EventArgs e)
        {
            serialPort1.Write("BUZ " + sp.Buzzer() + "\r\n");
        }
        private void button18_Click(object sender, EventArgs e)
        {
            serialPort1.Write("CHI 1000" + "\r\n");
        }
    }
    public class SerialPort_FUNC
    {
        public int FUNC_Count = 0;
        public int Hold_Count = 0;
        public int Auto_Count = 0;
        public int Frequency_Count = 0;
        public int Sampling_Count = 0;
        public int Range_Count = 0;
        public int Temperature_Count = 0;
        public int Comparator_Count = 0;
        public int CNO_Count = -1;
        public int CMD_Count = 0;
        public int Buzzer_Count = 0;
        public int ModeChange()
        {
            FUNC_Count++;
            return FUNC_Count % 2;
        }
        public int Hold_OnOff()
        {
            Hold_Count++;
            return Hold_Count%2;
        }
        public int Auto_OnOff()
        {
            Auto_Count++;
            return Auto_Count%2;
        }
        public int Frequency()
        {
            Frequency_Count++;
            return Frequency_Count % 2;
        }
        public int Sampling_Setting()
        {
            Sampling_Count++;
            return Sampling_Count % 2;
        }
        public int Range_Setting()
        {
            Range_Count++;
            return Range_Count % 7;
        }
        public int Temperature()
        {
            Temperature_Count++;
            return Temperature_Count % 2;
        }
        public int Comparator()
        {
            Comparator_Count++;
            return Comparator_Count % 2;
        }
        public int Comparator_Table()
        {
            CNO_Count++;
            return CNO_Count % 7 + 1;
        }
        public int Comparator_Mode()
        {
            CMD_Count++;
            return CMD_Count % 2;
        }
        public int Buzzer()
        {
            Buzzer_Count++;
            return Buzzer_Count % 3;
        }
    }
}
