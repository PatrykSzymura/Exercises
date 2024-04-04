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
    public partial class Form2 : Form
    {
        List<Car> Catalog;
        int Index;
        int Car_Type;

        public Form2(HashSet<Car> Car_Catalog, int Selected_Car)
        {
            InitializeComponent();
            this.Catalog = Car_Catalog.ToList();
            this.Index   = Selected_Car;
            

            var car = Catalog[Index];

            this.textBox_Brand.Text = car.GetAllValues()["Brand"]; ;
            this.textBox_Model.Text = car.GetAllValues()["Model"]; ;
            this.textBox_ProductionYear.Text = car.GetAllValues()["Production Year"]; ;

            if (car is FamilyCar) 
            {
                this.Car_Type = 1;
                this.label_Option1.Text = "Pojemnosc bagażnika";
                this.label_Option2.Text = "Ilosc siedzen";
                this.textBox_Option1.Text = car.GetAllValues()["Trunk Volume"];
                this.textBox_Option2.Text = car.GetAllValues()["Number Of Seats"];
            }
            else if (car is SportCar) 
            {
                this.Car_Type = 2;
                this.label_Option1.Text = "Przyspieszenie";
                this.label_Option2.Text = "Spalanie";
                this.textBox_Option1.Text = car.GetAllValues()["Acceleration"];
                this.textBox_Option2.Text = car.GetAllValues()["Fuel Consumption"];
            }
            else if(car is TerrainCar) 
            {
                this.Car_Type = 3;
                this.label_Option1.Text = "Conversja";
                this.label_Option2.Text = "Rodzaj skrzyni biegow";
                this.textBox_Option1.Text = car.GetAllValues()["Conversion"];
                this.textBox_Option2.Text = car.GetAllValues()["Gear Box Type"];
            }
        }

        public HashSet<Car> Get_Catalog() => this.Catalog.ToHashSet<Car>();

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void Label_ProductionYear_Click(object sender, EventArgs e)
        {

        }

        private void Label_Model_Click(object sender, EventArgs e)
        {

        }

        private void Label_Brand_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Brand_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            String[] prop = new string[5];

            //Czm dekrementacja?
            //Nie mam bladego pojęcia
            // Pętla sczytuje dane z pól od końca
            int i = 4;
            foreach (var field in this.groupBox_Prop.Controls)
            {
                
                if (field is TextBox)
                {
                    Console.WriteLine(field.ToString());
                    prop[i] = ((TextBox)field).Text;
                    i--;
                }
            }
            i = 0;

            switch (this.Car_Type)
            {
                case 1: //Family Car
                    this.Catalog[Index] = new FamilyCar(prop[0], prop[1], prop[2], prop[3], prop[4]);
                    break;
                case 2: //Sport Car
                    this.Catalog[Index] = new SportCar(prop[0], prop[1], prop[2], prop[3], prop[4]);
                    break;
                case 3: //Terrain Car
                    this.Catalog[Index] = new TerrainCar(prop[0], prop[1], prop[2], prop[3], prop[4]);
                    break;
                default: //Any above
                    MessageBox.Show("Wybierz poprawną opcje");
                    break;
            }

            this.Close();
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            this.Catalog.RemoveAt(Index);
            this.Close();
        }
    }
}
