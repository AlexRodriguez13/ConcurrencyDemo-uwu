using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConcurrencyDemo
{
    public partial class Form1 : Form
    {

        private delegate void SetProgressBarValueEvent(int values);
        private bool completed;
        private int i = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Thread t1= new Thread(new ThreadStart(
                 FillProgressBar
                ));

            t1.Start();
           
        }

        public void FillProgressBar()
        {
            while (!completed && i <= 100)
            {
                RequiredInvoke(i++);
                Thread.Sleep(500);
            }




            //for (int i = 1; i <= 100; i++)
            //{
            //    pgbStatus.Value = i;
                

        }
        public void RequiredInvoke(int value)
        {
            if (pgbStatus.InvokeRequired)
            {
                SetProgressBarValueEvent progressBarValueEvent = new SetProgressBarValueEvent(SetProgressBarValue);
                BeginInvoke(progressBarValueEvent, new object[] { value });
            }
            else
            {
                SetProgressBarValue(value);
            }
        }

        public void SetProgressBarValue(int value)
        {
            pgbStatus.Value = value;

        }
    }
   

}


