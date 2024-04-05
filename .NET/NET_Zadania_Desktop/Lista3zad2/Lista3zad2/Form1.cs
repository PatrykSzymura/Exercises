using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lista3zad2
{
    public partial class Form1 : Form
    {
        List<Cosiek> Points;
        List<Cosiek> Circles;
        List<Cosiek> Triangles;
        List<Cosiek> Poligons;
        
        public Form1()
        {
            InitializeComponent();
            Points      = new List<Cosiek>();
            Circles     = new List<Cosiek>();
            Triangles   = new List<Cosiek>();
            Poligons    = new List<Cosiek>();

            this.Points.Add(new Point(5, 5));
            this.Points.Add(new Point(3, 5));

            this.Circles.Add(new Circle(new Point(3, 2), 5));
            this.Circles.Add(new Circle(new Point(1,-2), 7));

            this.Triangles.Add(new Triangle(new Point(3,3), new Point(4,5),new Point(7,9)));
        }

        private void btn_Point_Click(object sender, EventArgs e)
        {
            Form2 PointForm = new Form2(0,Points);
            PointForm.ShowDialog();
        }

        private void button_Circle_Click(object sender, EventArgs e)
        {
            Form2 PointForm = new Form2(1,Circles);
            PointForm.ShowDialog();
        }

        private void button_Triangle_Click(object sender, EventArgs e)
        {
            Form2 PointForm = new Form2(2,Triangles);
            PointForm.ShowDialog();
        }

        private void button_Polygon_Click(object sender, EventArgs e)
        {
            Form2 PointForm = new Form2(3,Poligons);
            PointForm.ShowDialog();
        }

    }
}
