using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StopWatch_While__Class;

namespace StopWatch_while_
{
    public partial class Form1 : Form
    {
        StopWatch_While a = new StopWatch_While();
        public DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }
            return DateTime.Now;
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void BTN_Start_Click(object sender, EventArgs e)
        {
            BTN_Stop.Enabled = true;
            BTN_Reset.Enabled = true;
            BTN_Reset.Text = "구간기록";
            a.Start_Click();
            while(a.isStop == false)
            {
                Delay(10);
                if (a.GetHours() > 0)
                {
                    Lab_hour.Text = a.GetHours().ToString("00");
                    label4.Text = ":";
                }
                Lab_minute.Text = a.GetMinutes().ToString("00");
                Lab_sec.Text = a.GetSeconds().ToString("00");
                Lab_milisec.Text = a.GetMiliseconds().ToString("00");
                a.IncreaseMilisec();
                if (a.Record_Count > 0)
                {
                    if (a.GetHours2() > 0)
                    {
                        Lab_hour2.Text = a.GetHours2().ToString("00");
                        label1.Text = ":";
                    }
                    Lab_minute2.Text = a.GetMinutes2().ToString("00");
                    label2.Text = ":";
                    Lab_sec2.Text = a.GetSeconds2().ToString("00");
                    label3.Text = ".";
                    Lab_milisec2.Text = a.GetMiliseconds2().ToString("00");
                }
                a.IncreaseMilisec2();
            }
        }
        private void BTN_Pause_Click(object sender, EventArgs e)
        {
            a.Stop_Click();
            BTN_Reset.Text = "초기화";
        }
        private void BTN_Reset_Click(object sender, EventArgs e)
        {
            if (BTN_Reset.Text == "초기화")
            {
                a.Reset_Click();
                Lab_hour.Text = "";
                label4.Text = "";
                Lab_hour2.Text = "";
                label1.Text = "";
                Lab_minute2.Text = "";
                label2.Text = "";
                Lab_sec2.Text = "";
                label3.Text = "";
                Lab_milisec2.Text = "";
                Lab_Section.Text = "";
                Lab_SectionRecord.Text = "";
                Lab_Time.Text = "";
                Text_Section.Text = "";
                Text_Section_Score.Text = "";
                Text_Time.Text = "";
                BTN_Reset.Enabled = false;
                BTN_Stop.Enabled = false;
                if (a.GetHours() > 0)
                {
                    Lab_hour.Text = a.GetHours().ToString("00");
                    label4.Text = ":";
                }
                Lab_minute.Text = a.GetMinutes().ToString("00");
                Lab_sec.Text = a.GetSeconds().ToString("00");
                Lab_milisec.Text = a.GetMiliseconds().ToString("00");
            }
            else
            {
                Lab_Section.Text = "구간";
                Lab_SectionRecord.Text = "구간기록";
                Lab_Time.Text = "전체시간";
                Text_Section.AppendText(a.RecordCount().ToString("00") + "\r\n");
                if (a.hours2 > 0)
                {
                    Text_Section_Score.AppendText(a.GetHours2().ToString("00") + ":");
                }
                Text_Section_Score.AppendText(a.GetMinutes2().ToString("00") + ":" + a.GetSeconds2().ToString("00") + "."
                    + a.GetMiliseconds2().ToString("00") + "\r\n");
                a.Record_Click();
                if (a.GetHours() > 0)
                {
                    Text_Time.AppendText(Lab_hour.Text + ":");
                }
                Text_Time.AppendText(Lab_minute.Text + ":" + Lab_sec.Text + "." + Lab_milisec.Text + "\r\n");
            }
        }
    }
    /*public class StopWatch_While
    {
        public int hours = 0;
        public int minutes = 0;
        public int seconds = 0;
        public int miliseconds = 0;
        public int hours2 = 0;
        public int minutes2 = 0;
        public int seconds2 = 0;
        public int miliseconds2 = 0;
        public int Record_Count = 0;
        public bool isStop = false;
        public bool isStop2 = false;

        public void IncreaseMilisec()
        {
            if (miliseconds > 99)
            {
                miliseconds = 0;
                IncreaseSec();
            }
            else
            {
                miliseconds++;
            }
        }
        public void IncreaseSec()
        {
            if (seconds > 59)
            {
                seconds = 0;
                IncreaseMinute();
            }
            else
            {
                seconds++;
            }
        }
        public void IncreaseMinute()
        {
            if (minutes > 59)
            {
                minutes = 0;
                IncreaseHour();
            }
            else
            {
                minutes++;
            }
        }
        public void IncreaseHour()
        {
            hours++;
        }
        public void IncreaseMilisec2()
        {
            if (miliseconds > 99)
            {
                miliseconds2 = 0;
                IncreaseSec2();
            }
            else
            {
                miliseconds2++;
            }
        }
        public void IncreaseSec2()
        {
            if (seconds2 > 59)
            {
                seconds2 = 0;
                IncreaseMinute2();
            }
            else
            {
                seconds2++;
            }
        }
        public void IncreaseMinute2()
        {
            if (minutes2 > 59)
            {
                minutes2 = 0;
                IncreaseHour2();
            }
            else
            {
                minutes2++;
            }
        }
        public void IncreaseHour2()
        {
            hours2++;
        }
        public DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }
            return DateTime.Now;
        }
        public void Start_Click()
        {
            isStop = false;
            isStop2 = false;
        }
        public void Stop_Click()
        {
            isStop = true;
            isStop2 = true;
        }
        public void Reset_Click()
        {
            hours = 0;
            minutes = 0;
            seconds = 0;
            miliseconds = 0;
            hours2 = 0;
            minutes2 = 0;
            seconds2 = 0;
            miliseconds2 = 0;
            Record_Count = 0;
            isStop = false;
            isStop2 = false;
        }
        public void Record_Click()
        {
            hours2 = 0;
            minutes2 = 0;
            seconds2 = 0;
            miliseconds2 = 0;
        }
        public int RecordCount()
        {
            Record_Count++;
            return Record_Count;
        }
        public int GetHours()
        {
            return hours;
        }
        public int GetHours2()
        {
            return hours2;
        }
        public int GetMinutes()
        {
            return minutes;
        }
        public int GetMinutes2()
        {
            return minutes2;
        }
        public int GetSeconds()
        {
            return seconds;
        }
        public int GetSeconds2()
        {
            return seconds2;
        }
        public int GetMiliseconds()
        {
            return miliseconds;
        }
        public int GetMiliseconds2()
        {
            return miliseconds2;
        }
    }*/
}
