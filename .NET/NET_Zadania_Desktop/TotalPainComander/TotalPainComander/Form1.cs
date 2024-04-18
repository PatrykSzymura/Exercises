using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Shell;

namespace TotalPainComander
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            refresh();
        }

        public void refresh()
        {
            this.Contents.Controls.Clear();
            for (int i = 0; i < 2; i++)
                this.Contents.Controls.Add(new Panel($"File Window Nr.{i+1}"));
            
        }
    }
}
