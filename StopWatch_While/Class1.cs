using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopWatch_While__Class
{
    public class StopWatch_While
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
    }
}
