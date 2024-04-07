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
        public HashSet<Car> Catalog;

        public Form1()
        {
            InitializeComponent();

            if (listBox_Cars.SelectedIndex == -1)
            {
                this.btn_ShowProp.Enabled = false;
            };

            Catalog = new HashSet<Car>();
            Catalog.Add(new SportCar("JD", "Jd", "2137", "Szybko", "21/37"));
            Catalog.Add(new FamilyCar("Volvo", "C3", "2002", "4m^2", "4"));
            Catalog.Add(new TerrainCar("Renoult", "Laguna", "2001", "4x4", "9"));

            FamilyCar x = new FamilyCar("Volvo", "C3", "2002", "4m^2", "4");
            x.aaa = 5;

            refreshList(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
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
            //HashSet<string> set = new HashSet<string>();
            String[] values = new string[5];

            int i = 0;
            foreach(var item in this.BaseOptionGroup.Controls)
            { 
                if(item is TextBox) 
                {
                    values[i] = ((TextBox)item).Text.ToLower();
                    Console.WriteLine(values[i]);
                    i++; 
                } 
            }
            
            foreach(var item in this.AdditionalOptionGroup.Controls) 
            {
                if (item is TextBox) 
                {
                    values[i] = ((TextBox)item).Text.ToLower();
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
            refreshList();

        }

        void refreshList()
        {
            listBox_Cars.Items.Clear();
            foreach( var Car in Catalog )
            {
                Console.WriteLine(Car.GetValuesString().ToString());
                listBox_Cars.Items.Add(Car.GetValuesString());
            }
            
        }

        private void listBox_Cars_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(listBox_Cars.SelectedIndex.ToString());

            if (listBox_Cars.SelectedIndex >= 0) this.btn_ShowProp.Enabled = true;
        }

        private void label_Option2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listBox_Cars_DoubleClick(object sender, EventArgs e)
        {
            Console.WriteLine(sender.ToString());
        }

        private void btn_ShowProp_Click(object sender, EventArgs e)
        {
            int index_Of_Item = this.listBox_Cars.SelectedIndex;
            Console.WriteLine(index_Of_Item.ToString());
            Form2 form = new Form2(Catalog,index_Of_Item);
            form.ShowDialog();
            this.btn_ShowProp.Enabled = false;
            this.Catalog = form.Get_Catalog();
            refreshList();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3(Catalog);
            form.ShowDialog();
        }
    }
}
