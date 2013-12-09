// Shone JIN, 2013.12
// this file deals with VIEW and CONTROL in MVC pattern
// Control is driven by button click events, which change the View at the same time


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace homework_09
{
    public partial class Form1 : Form
    {
        public static int stepNum = 0;
        public static int sum = 0; // current sum of sub array
        public static Calculate calculate; // model part of MVC
        public static int Row_Num;
        public static int Clm_Num;
        public static int[,] data; // input data
        public static int[,] colorCell = new int[33,33]; // color of each cell
        public static int autoPressed = 0; // how many times auto button is pressed
        public Form1()
        {            
            InitializeComponent();
            timer1.Tick += new EventHandler(TimerEventProcessor);
        }

        //
        // open system file dialog and chose input file
        //
        private void btn_file_open_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            calculate = new Calculate();
                            calculate.setMode(getMode());
                            calculate.setFile(myStream);
                            calculate.init(false);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:  " + ex.Message);
                }
            }
        }

        //
        // fill the metric with input number
        //
        public void setMetricContent(int m)
        {

        }

        //
        // set cell[x,y] with color specified
        //
        private void setMetricColor(int color, int x, int y)
        {
            if(color == 1)
            {
                this.listView1.Items[x].UseItemStyleForSubItems = false;
                this.listView1.Items[x].SubItems[y].BackColor = System.Drawing.Color.LightPink;
            }
            else
            {
                this.listView1.Items[x].UseItemStyleForSubItems = false;
                this.listView1.Items[x].SubItems[y].BackColor = System.Drawing.Color.LightBlue;
            }
        }
        //
        // get mode from radio buttons
        //
        private int getMode()
        {
            if (rbtn_a.Checked)
            {
                return 1;
            }
            else if (rbtn_h.Checked)
            {
                return 2;
            }
            else if (rbtn_v.Checked)
            {
                return 3;
            }
            else if (rbtn_hv.Checked)
            {
                return 4;
            }
            else
            {
                return 0;
            }
        }

        //
        // update and show current step number in text box
        //
        private void setStepNum(int n)
        {
            tb_step.Text = n.ToString();
            tb_step.Update();
        }

        //
        // set current sum of sub array in text box
        //
        private void setSum(int n)
        {
            tb_sum.Text = n.ToString();
            tb_sum.Update();
        }

        //
        // open system file dialog and chose input
        //
        private void btn_file_auto_Click(object sender, EventArgs e)
        {
            calculate = new Calculate();
            calculate.setMode(getMode());
            calculate.init(true);
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            nextStep();
        }

        //
        // show next step and change color of sub array
        //
        private void nextStep()
        {
            if (calculate.nextStep() == -1)
            {
                MessageBox.Show("This is the last step");
                return;
            }

            int i, j;
            for (i = 0; colorCell[i, 0] != -1; i++)
            {
                for (j = 0; colorCell[0, j] != -1; j++)
                {
                    setMetricColor(colorCell[i, j], i, j);
                }
            }
            stepNum++;
            setStepNum(stepNum);
            sum = calculate.getSum();
            setSum(sum);
        }

        //
        // handler of timer event, move on one step
        //
        private void TimerEventProcessor(Object myObject,EventArgs myEventArgs)
        {
            if (calculate.nextStep() == -1)
            {
                MessageBox.Show("This is the last step");
                return;
            }

            int i, j;
            for (i = 0; colorCell[i, 0] != -1; i++)
            {
                for (j = 0; colorCell[0, j] != -1; j++)
                {
                    setMetricColor(colorCell[i, j], i, j);
                }
            }
            stepNum++;
            setStepNum(stepNum);
            sum = calculate.getSum();
            setSum(sum);
        }

        //
        // go back to last step, if it is not the first one
        //
        private void btn_former_Click(object sender, EventArgs e)
        {
            if (calculate.formerStep() == -1)
            {
                MessageBox.Show("This is the first step");
                return;
            }
            calculate.formerStep();
            int i, j;
            for (i = 0; colorCell[i, 0] != -1; i++)
            {
                for (j = 0; colorCell[0, j] != -1; j++)
                {
                    setMetricColor(colorCell[i, j], i, j);
                }
            }
            stepNum--;
            setStepNum(stepNum);
            sum = calculate.getSum();
            setSum(sum);
        }

        //
        // auto next step: ON or OFF
        //
        private void btn_auto_Click(object sender, EventArgs e)
        {
            autoPressed++;
            if(autoPressed %2 == 0)
            {
                timer1.Start();
                btn_auto.Text = "auto off";
                btn_file_open.Enabled = false;
                btn_file_auto.Enabled = false;
                btn_next.Enabled = false;
                btn_former.Enabled = false;
            }
            else
            {
                timer1.Stop();
                btn_auto.Text = "auto";
                btn_file_open.Enabled = true;
                btn_file_auto.Enabled = true;
                btn_next.Enabled = true;
                btn_former.Enabled = true;
            }
        }
    }
}
