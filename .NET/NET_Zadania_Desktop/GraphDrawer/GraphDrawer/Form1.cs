using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphDrawer
{
    public partial class Form1 : Form
    {
        int NumOfFuntion;
        GraphDataHolder Data;

        public Form1()
        {
            InitializeComponent();
             Data = new GraphDataHolder();
            
        }

        private void checkBox_First_CheckedChanged(object sender, EventArgs e)
        {
            //this.checkBox_First.Checked =   true;
            this.checkBox_Second.Checked = false;
            
            this.NumOfFuntion = 1;
        }

        private void checkBox_Second_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBox_First.Checked = false;
            //this.checkBox_Second.Checked = true;
            this.NumOfFuntion = 2;
        }

        private void btn_Draw_Click(object sender, EventArgs e)
        {   
            this.chart1.Series.Clear();
            int NumOfEquasion = 0;

            if (this.checkBox_First.Checked) NumOfEquasion = 1;
            else if (this.checkBox_Second.Checked) NumOfEquasion = 2;

            Console.WriteLine("Clicked");

            switch (NumOfEquasion)
            {
                case 0:
                    break;
                case 1:
                    Data = new GraphDataHolder((int)this.numericUpDown1.Value,10);
                    break;
                case 2:
                    Data = new GraphDataHolder
                        (
                            (int)this.numericUpDown1.Value, 
                            (int)this.numericUpDown2.Value, 
                            10
                        );
                    break;
            }

            this.chart1.Series.Add(this.Data.GetData());
        }
    }
}
