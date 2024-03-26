using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NET_Zadania_Desktop
{
    public partial class Form1 : Form
    {
        protected HashSet<Car> Catalog;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Catalog = new HashSet<Car>();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void option_Selector_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(option_Selector.SelectedItem.ToString());

            // Enabling textboxes upon selection
            foreach (var item in this.BaseOptionGroup.Controls)
            {
                if (item is TextBox)
                {
                    if (item is TextBox)
                    {
                        (item as TextBox).Enabled = true;
                    }
                }
            }

            foreach (var item in this.AdditionalOptionGroup.Controls) 
            {
                if (item is TextBox)
                {
                    (item as TextBox).Enabled = true;
                }
            }
        
            // Enabling Button upon selection
            this.btn_Add.Enabled = true;

            // Changing Option Names Based on ComboBox
            switch(option_Selector.SelectedIndex)
            {
                case 0:
                    this.label_Option1.Text = "Pojemnosc bagażnika";
                    this.label_Option2.Text = "Ilosc siedzen";
                    break;
                case 1:
                    this.label_Option1.Text = "Przyspieszenie";
                    this.label_Option2.Text = "Spalanie";
                    break;
                case 2:
                    this.label_Option1.Text = "Conversja";
                    this.label_Option2.Text = "Rodzaj skrzyni biegow";
                    break;
                default:
                    MessageBox.Show("Wybierz poprawną opcje");
                    break;
            }
        }

        private void Label_ProductionYear_Click(object sender, EventArgs e)
        {

        }

        private void Label_Brand_Click(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            HashSet<string> set = new HashSet<string>();
            String[] values = new string[5];

            int i = 0;
            foreach(var item in this.BaseOptionGroup.Controls)
            { 
                if(item is TextBox) 
                { 
                    values[i] = item.ToString();i++; 
                } 
            }
            i = 0;
            foreach(var item in this.AdditionalOptionGroup.Controls) 
            {
                if (item is TextBox) 
                { 
                    values[i] = item.ToString();
                    i++; 
                } 
            }
            
            switch (option_Selector.SelectedIndex)
            {
                case 0: //Family Car
                    this.Catalog.Add(new FamilyCar(values[0], values[1], values[2], values[3], values[4]));
                    break;
                case 1: //Sport Car
                    this.Catalog.Add(new SportCar(values[0], values[1], values[2], values[3], values[4]));
                    break;
                case 2: //Terrain Car
                    this.Catalog.Add(new TerrainCar(values[0], values[1], values[2], values[3], values[4]));
                    break;
                default: //Any above
                    MessageBox.Show("Wybierz poprawną opcje");
                    break;
            }

        }

        private void listBox_Cars_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listBox_Cars.Items.AddRange(new object[] {"XD"});
            foreach(var car in this.Catalog)
            {
                this.listBox_Cars.Items.AddRange(new object[] {car.GetAllValues() });
            }
        }
    }
}
