using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.DAQmx;

namespace ReadDigitChannel
{
    public partial class Form1 : Form
    {
        private Task myTask;
        DigitalSingleChannelReader myDigitalReader;
        //private System.ComponentModel.IContainer components;
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.DILine, PhysicalChannelAccess.External));
        }
       
        private void BTN_Start_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                myTask = new Task();
                myTask.DIChannels.CreateChannel(comboBox1.Text, "", ChannelLineGrouping.OneChannelForAllLines);
                myDigitalReader = new DigitalSingleChannelReader(myTask.Stream);

                timer1.Enabled = true;
                BTN_Start.Enabled = false;
                BTN_Stop.Enabled = true; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                myTask.Dispose();
                BTN_Start.Enabled = true;
                BTN_Stop.Enabled = false;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                bool[] readData;
                readData = myDigitalReader.ReadSingleSampleMultiLine();

                checkBox1.Checked = readData[0];
                checkBox2.Checked = readData[1];
                checkBox3.Checked = readData[2];
                checkBox4.Checked = readData[3];
                checkBox5.Checked = readData[4];
                checkBox6.Checked = readData[5];
                checkBox7.Checked = readData[6];
                checkBox8.Checked = readData[7];

                int val = 0;
                for (int i = 0; i < readData.Length; i++)
                {
                    val += 1 << i;
                }
                textBox1.Text = String.Format("0x{0:X}", val);
            }
            catch(DaqException exception)
            {
                timer1.Enabled = false;
                myTask.Dispose();
                MessageBox.Show(exception.Message);
                BTN_Start.Enabled = true;
                BTN_Stop.Enabled = false;
            }
            catch(IndexOutOfRangeException exception)
            {
                timer1.Enabled = false;
                myTask.Dispose();
                MessageBox.Show("Error: You must specify eight lines in the channel string (i.e.,0:7).");
                BTN_Start.Enabled = true;
                BTN_Stop.Enabled = false;
            }
        }

        private void BTN_Stop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            myTask.Dispose();
            BTN_Start.Enabled = true;
            BTN_Stop.Enabled = false;
        }
    }
}
