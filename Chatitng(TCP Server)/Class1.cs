using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace MyServer
{
    public class MyServer_
    {
        public TcpListener Server = null;
        public TcpClient ClientSocket = null;
        public NetworkStream stream;
        public byte[] buff = new byte[1024];
        public bool connected = false;

        public void ServerStart(TextBox textBox)
        {
            Server = new TcpListener(IPAddress.Any, 1024);
            ClientSocket = default(TcpClient);
            Server.Start();
            ClientSocket = Server.AcceptTcpClient();
            if (textBox.InvokeRequired)
            {
                textBox.BeginInvoke(new Action(() =>
                {
                    textBox.AppendText("클라이언트가 연결 되었습니다. \r\n");
                }));
            }
            connected = true;
            stream = ClientSocket.GetStream();
            Thread Receive_ = new Thread(() => Receive(textBox));
            Receive_.Start();
            if (!connected)
            {
                Receive_.Join();
            }
        }
        public void SendMessage(TextBox textBox1, TextBox textBox2)
        {
            textBox2.AppendText(DateTime.Now.ToString("[hh:mm:ss]") + " Me : " + textBox1.Text + "\r\n");
            stream = ClientSocket.GetStream();
            byte[] buf = Encoding.Default.GetBytes(textBox1.Text);
            byte[] data = new byte[1024];
            for (int i = 0; i < buf.Length; i++)
            {
                data[i] = buf[i];
            }
            stream.Write(data, 0, data.Length);
            textBox1.Clear();
        }
        public void Receive(TextBox textBox)
        {
            while (connected)
            {
                Thread.Sleep(5);
                if (stream.CanRead)
                {
                    buff = new byte[1024];
                    stream.Read(buff, 0, 1024);
                    if (Encoding.Default.GetString(buff) == "Leave")
                    {
                        if (textBox.InvokeRequired)
                        {
                            textBox.BeginInvoke(new Action(() =>
                            {
                                textBox.AppendText("클라이언트의 연결이 해제되었습니다.");
                            }));
                        }
                    }
                    else
                    {
                        if (textBox.InvokeRequired)
                        {
                            textBox.BeginInvoke(new Action(() =>
                            {
                                textBox.AppendText(DateTime.Now.ToString("[hh:mm:ss]") + " You : " + Encoding.Default.GetString(buff));
                                textBox.AppendText("\r\n");
                            }));
                        }
                    }
                }
                //connected = ClientSocket.Connected;
            }
        }
    }
}
