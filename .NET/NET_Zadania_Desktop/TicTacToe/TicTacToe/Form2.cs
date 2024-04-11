using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class GameEndPopup : Form
    {
        public GameEndPopup(int WhoWon)
        {
            InitializeComponent();
            switch(WhoWon)
            {
                case 0:
                    this.label1.Text = "0 Won";
                    break;
                case 1:
                    this.label1.Text = "X Won";
                    break;
                case 2:
                    this.label1.Text = "Draw";
                    break;
            }
        }
    }
}
