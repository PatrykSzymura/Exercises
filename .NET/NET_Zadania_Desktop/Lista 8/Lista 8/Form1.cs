using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Lista_8
{
    public partial class Form1 : Form
    {
        int[] chosen_numbers;
        Thread[] threads;

        public Form1()
        {
            InitializeComponent();
        }

        public int[] draw_numbers()
        {
            int[] numbers = new int[6];
            Random random = new Random();
            foreach (int i in numbers) numbers[i] = random.Next(1, 50);
            return numbers;
        }

        

        public int compare(int[] toCompare)
        {
            int[] numbers = this.chosen_numbers;
            int count = 0;
            foreach (int i in numbers)
            {
                foreach(int j in toCompare)
                {
                    if (i == j) count++;
                }
            }
            return count;
        }

        public void start()
        {
            chosen_numbers = new int[6];
            chosen_numbers = draw_numbers();
            this.search.Text = chosen_numbers.ToString();

            this.threads = new Thread[6];
            for (int i = 0;i < 6 ; i++)
            {
                threads[i] = new Thread(() => this.thread_Function());
            }

        }  

        public void thread_Function()
        {
            int[] tmp = draw_numbers();
            int Count = this.compare(tmp);
            this.list_numbers.Items.Add(tmp.ToString());
            if (Count == 3)
            {
                int t = (Int16.Parse(this.counter3.Text) + 1);
                this.counter3.Text = t.ToString();
            }
            else if (Count == 4)
            {
                int t = (Int16.Parse(this.counter4.Text) + 1);
                this.counter4.Text = t.ToString();
            }
            else if (Count == 5)
            {
                int t = (Int16.Parse(this.counter5.Text) + 1);
                this.counter5.Text = t.ToString();
            }
            else if (Count == 6)
            {
                int t = (Int16.Parse(this.counter6.Text) + 1);
                this.counter6.Text = t.ToString();
                this.stop();
            }
        }

        public void stop()
        {

        }

        private void btn_start_Click(object sender, EventArgs e)
        {

        }

        private void btn_stop_Click(object sender, EventArgs e)
        {

        }

        private void btn_test_Click(object sender, EventArgs e)
        {

        }
    }
}
