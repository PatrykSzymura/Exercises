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
    public partial class Form1 : Form
    {
        TicTacToe Game;
        public Form1()
        {
            InitializeComponent();
            Game = new TicTacToe();           
        }

        private void btn_0_0_Click(object sender, EventArgs e)
        {
            
            ((System.Windows.Forms.Button)sender).Text = Game.GetChar();
            ((System.Windows.Forms.Button)sender).Enabled = false;

            Point? ClickPosition =  GetIndex(this.tableLayoutPanel1, tableLayoutPanel1.PointToClient(Cursor.Position));

            Game.MakeMove(ClickPosition.Value.Y, ClickPosition.Value.X);

            Game.DisplayBoard();
            if (Game.IsOver())
            {
                //Console.WriteLine("pomidor");
                int WhoWon = 0;
                if (Game.CheckFullBoard()) 
                    WhoWon = 2;
                else if (Game.GetTurn())       
                    WhoWon = 0;
                else                           
                    WhoWon = 1;
                GameEndPopup popup = new GameEndPopup(WhoWon);
                popup.Show();

            }

        }
        
        // Taken From
        // https://stackoverflow.com/questions/15449504/how-do-i-determine-the-cell-being-clicked-on-in-a-tablelayoutpanel
        public Point? GetIndex(TableLayoutPanel tlp, Point point)
        {
            // Method adapted from: stackoverflow.com/a/15449969
            if (point.X > tlp.Width || point.Y > tlp.Height)
                return null;

            int w = 0, h = 0;
            int[] widths = tlp.GetColumnWidths(), heights = tlp.GetRowHeights();

            int i;
            for (i = 0; i < widths.Length && point.X > w; i++)
            {
                w += widths[i];
            }
            int col = i - 1;

            for (i = 0; i < heights.Length && point.Y + tlp.VerticalScroll.Value > h; i++)
            {
                h += heights[i];
            }
            int row = i - 1;

            return new Point(col, row);
        }
    }
}
