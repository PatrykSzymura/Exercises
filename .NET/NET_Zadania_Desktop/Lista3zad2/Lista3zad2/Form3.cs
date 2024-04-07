using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Lista3zad2
{
    public partial class Form3 : Form
    {
        protected int Type;
        protected List<Cosiek> Collection;
        protected int Selected;

        public Form3(int type, List<Cosiek> collection)
        {
            InitializeComponent();
            this.Type = type;
            this.Collection = collection;

            this.button1.Text= "Dodaj";

            switch(type)
            {
                case 0:
                    this.numericUpDown1.Visible = false;
                    this.numericUpDown1.Value = 1;
                    this.label_Num_Of_Points.Text = "Dodaj Dane do Punktu";
                    break;
                case 1:
                    this.numericUpDown1.Visible = false;
                    this.numericUpDown1.Value = 1;
                    this.label_Num_Of_Points.Text = "Dodaj Dane do Kola";
                    break;
                case 2:
                    this.numericUpDown1.Visible = false;
                    this.numericUpDown1.Value = 3;
                    this.label_Num_Of_Points.Text = "Dodaj Dane do Trojkata";
                    break;
                case 3:
                    this.numericUpDown1.Visible = true;
                    break;
            }
        }

        public Form3(int type, List<Cosiek> collection, int Selected) : this(type, collection)
        {
            this.Selected = Selected;
            this.button1.Text = "Modyfikuj";
            this.button1.Click -= new EventHandler(button1_Click); // remove Button1_Click
            this.button1.Click += new EventHandler(button1_Click_Modify);
            int size = this.Collection.Count;
            //Console.WriteLine(collection[0].GetType());
            var point = collection[Selected];
            switch (type)
            {
                case 0:
                    foreach(var ControlBox in this.flowLayoutPanel1.Controls)
                    {
                        ((PointController)ControlBox).numericUpDown1.Value = ((Point)point).x;
                        ((PointController)ControlBox).numericUpDown2.Value = ((Point)point).y;
                    }
                    break;
                case 1:
                    
                    //Console.WriteLine(((Circle)point).r);
                    foreach (var ControlBox in this.flowLayoutPanel1.Controls)
                    {
                        if (ControlBox is PointController)
                        {
                            ((PointController)ControlBox).numericUpDown1.Value = ((Circle)point).x.x;
                            ((PointController)ControlBox).numericUpDown2.Value = ((Circle)point).x.y;
                        }
                        else if (ControlBox is R_Controller)
                        {
                            ((R_Controller)ControlBox).numericUpDown2.Value = ((Circle)point).r;
                        }
                    }
                    break;
                case 2:
                    int i = 0;
                    foreach (PointController ControlBox in this.flowLayoutPanel1.Controls)
                    {
                        ControlBox.numericUpDown1.Value = ((Triangle)point).points()[i].x;
                        ControlBox.numericUpDown1.Value = ((Triangle)point).points()[i].y;
                        i++;
                    }
                    i = 0;
                    break;
                case 3:
                    this.numericUpDown1.Value = ((Polygon)point).Points.Count;
                    Console.WriteLine(this.numericUpDown1.Value);
                    this.numericUpDown1.Visible = false;
                    int z = 0; 
                    

                    foreach(PointController ControlBox in this.flowLayoutPanel1.Controls)
                    {
                        ControlBox.numericUpDown1.Value = ((Polygon)point).Points[z].x;
                        ControlBox.numericUpDown2.Value = ((Polygon)point).Points[z].y;
                        z++;  
                    }
                    break;
                
            }
        }



        private void refresh()
        {
            this.flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < this.numericUpDown1.Value; i++)
            {
                this.flowLayoutPanel1.Controls.Add(new PointController());
            }
            if (this.Type == 1) this. flowLayoutPanel1.Controls.Add(new R_Controller());
        }

        private void setLimit(int limit)
        {
            this.numericUpDown1.Value = limit;

        }

        public List<Cosiek> GetData() => this.Collection;

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            refresh();

            if (this.numericUpDown1.Value == 0) this.button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int t1 = 0,
                t2 = 0;
            switch(this.Type)
            {
                case 1:
                    foreach (var ControlBox in this.flowLayoutPanel1.Controls)
                    {
                        if (ControlBox is PointController)
                        {
                            t1 = Convert.ToInt32(((PointController)ControlBox).numericUpDown1.Value);
                            t2 = Convert.ToInt32(((PointController)ControlBox).numericUpDown2.Value);
                        }
                        else if (ControlBox is R_Controller)
                        {
                            Collection.Add(new Circle(new Point(t1, t2), Convert.ToInt32(((R_Controller)ControlBox).numericUpDown2.Value)));
                        }
                    }
                    break;
                default:
                    List<Point> tmp = new List<Point>();
                    foreach (var ControlBox in this.flowLayoutPanel1.Controls)
                    {
                        if (ControlBox is PointController)
                        {
                            t1 = Convert.ToInt32(((PointController)ControlBox).numericUpDown1.Value);
                            t2 = Convert.ToInt32(((PointController)ControlBox).numericUpDown2.Value);
                            tmp.Add(new Point(t1, t2));
                        }
                    }
                    switch (this.Type)
                    {
                        case 0:
                            Collection.Add((Point)tmp[0]); break;
                        case 2:
                            Collection.Add(new Triangle((Point)tmp[0], (Point)tmp[1],(Point)tmp[2])); break;
                        default :
                            Point[] arr = new Point[tmp.Count];
                            for (int i = 0; i < tmp.Count; i++)
                                arr[i] = tmp[i];
                            Collection.Add(new Polygon(arr));
                            break;
                    }

                    break;
            }
            Close();
        }
    
        private void button1_Click_Modify(object sender, EventArgs e)
        {
            int t1 = 0,
                t2 = 0;
            switch (this.Type)
            {
                case 1:
                    foreach (var ControlBox in this.flowLayoutPanel1.Controls)
                    {
                        if (ControlBox is PointController)
                        {
                            t1 = Convert.ToInt32(((PointController)ControlBox).numericUpDown1.Value);
                            t2 = Convert.ToInt32(((PointController)ControlBox).numericUpDown2.Value);
                        }
                        else if (ControlBox is R_Controller)
                        {
                            Collection[this.Selected] = new Circle(new Point(t1, t2), Convert.ToInt32(((R_Controller)ControlBox).numericUpDown2.Value));
                        }
                    }
                    break;
                default:
                    List<Point> tmp = new List<Point>();
                    foreach (var ControlBox in this.flowLayoutPanel1.Controls)
                    {
                        if (ControlBox is PointController)
                        {
                            t1 = Convert.ToInt32(((PointController)ControlBox).numericUpDown1.Value);
                            t2 = Convert.ToInt32(((PointController)ControlBox).numericUpDown2.Value);
                            tmp.Add(new Point(t1, t2));
                        }
                    }
                    switch (tmp.Count)
                    {
                        case 1:
                            Collection[this.Selected] = (Point)tmp[0]; break;
                        case 3:
                            Collection[this.Selected] = new Triangle((Point)tmp[0], (Point)tmp[1], (Point)tmp[2]); break;
                        default:
                            Point[] arr = new Point[tmp.Count];
                            for (int i = 0; i < tmp.Count; i++)
                                arr[i] = tmp[i];
                            Collection[this.Selected] = new Polygon(arr);
                            break;
                    }

                    break;
            }
            Close();

        }
    }
}
