using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lista3zad2
{
    public partial class Form2 : Form
    {
        protected List<Cosiek> Collection;
        protected int Type;

        public Form2(int type, List<Cosiek> collection)
        {
            InitializeComponent();
            this.Collection = collection;
            this.Type = type;
            SetData();
            refreshList();
        }

        void refreshList()
        {
            this.listBox_Object.Items.Clear();
            foreach (var thing in Collection)
            {
                this.listBox_Object.Items.Add(thing.Wypiszmnie());


                //Console.WriteLine(thing.ToString());
            }
            this.unlockButtons(false);
        }

        void SetData() 
        {
            switch (this.Type)
            {
                case 0:
                    this.groupBox_Object.Text = "Points";
                    break;
                case 1:
                    this.groupBox_Object.Text = "Circle";
                    break;
                case 2:
                    this.groupBox_Object.Text = "Triangle";
                    break;
                case 3:
                    this.groupBox_Object.Text = "Polygon";
                    break;
            }
        }

        void SaveData(List<Cosiek> data)
        {
            foreach (var thing in data)
                Console.WriteLine(thing.Wypiszmnie());
            refreshList();

        }

        void AddData(Cosiek ksztalt) => this.Collection.Add(ksztalt);
        

        void unlockButtons(bool unlock)
        {
            if (unlock)
            {
                this.button2.Enabled = true;
                this.button3.Enabled = true;
            }
            else
            {
                this .button2.Enabled = false;
                this .button3.Enabled = false;
            }
        }

        private void listBox_Object_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.unlockButtons(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = this.listBox_Object.SelectedIndex;
            Form3 form3 = new Form3(this.Type, Collection,i);
            form3.ShowDialog();
            SaveData(form3.GetData());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(this.Type, Collection);
            form3.ShowDialog();
            SaveData(form3.GetData());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Collection.RemoveAt(this.listBox_Object.SelectedIndex);
            refreshList();
        }
    }
}
