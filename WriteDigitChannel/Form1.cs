using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.DAQmx;

namespace WriteDigitChannel
{
    public partial class Form1 : Form
    {
        //private System.ComponentModel.Container components = null;
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.DOLine, PhysicalChannelAccess.External));
        }

        /*protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if(components1 != null)
                {
                    components1.Dispose();
                }
            }
            base.Dispose();
        }*/
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                using(Task digitalWriteTask = new Task())
                {
                    digitalWriteTask.DOChannels.CreateChannel(comboBox1.Text, "", ChannelLineGrouping
                        .OneChannelForAllLines);
                    bool[] dataArray = new bool[8];
                    dataArray[0] = bit0CheckBox.Checked;
                    dataArray[1] = bit1CheckBox.Checked;
                    dataArray[2] = bit2CheckBox.Checked;
                    dataArray[3] = bit3CheckBox.Checked;
                    dataArray[4] = bit4CheckBox.Checked;
                    dataArray[5] = bit5CheckBox.Checked;
                    dataArray[6] = bit6CheckBox.Checked;
                    dataArray[7] = bit7CheckBox.Checked;
                    DigitalSingleChannelWriter writer = new DigitalSingleChannelWriter(digitalWriteTask.Stream);
                    writer.WriteSingleSampleMultiLine(true, dataArray);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
