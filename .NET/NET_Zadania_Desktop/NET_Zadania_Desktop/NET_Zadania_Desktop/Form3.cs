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
    public partial class Form3 : Form
    {
        HashSet<Car> Catalog;
        public Form3(HashSet<Car> Car_Catalog)
        {
            InitializeComponent();
            this.Catalog = Car_Catalog;
        }

        void refreshList(string search)
        {
            listBox_Search_Ress.Items.Clear();
            bool tmp = false;
            foreach (var Car in Catalog)
            {
                Console.WriteLine(Car.GetValuesString().ToString());

                foreach(var prop in Car.GetAllValues().Values) {
                    if (prop.ToString().ToLower() == search) 
                    {
                        tmp = true;
                    }
                } 
                if (tmp) listBox_Search_Ress.Items.Add(Car.GetValuesString()); 
                tmp = false;
            }

        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string Search = this.textBox_Search.Text.ToLower();
            refreshList(Search);
        }
    }
}
