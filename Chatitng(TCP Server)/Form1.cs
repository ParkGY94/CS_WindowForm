﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using MyServer;

namespace Chatting
{
    public partial class Form1 : Form
    {
        MyServer_ Server = new MyServer_();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.AppendText("서버가 동작합니다. \r\n");
            Thread Server_ = new Thread(()=>Server.ServerStart(textBox2));
            Server_.Start();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Server.SendMessage(textBox1, textBox2);
        }
    }
}
