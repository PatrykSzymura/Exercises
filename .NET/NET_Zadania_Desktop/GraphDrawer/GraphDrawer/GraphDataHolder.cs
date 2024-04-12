using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace GraphDrawer
{
    public class GraphDataHolder
    {
        List<int> Data;
        int NumOfValues;
        int a;
        int b;
        

        public GraphDataHolder() 
        {
            Data = new List<int>();
            this.a = 0;
            this.b = 0;
            this.NumOfValues = 100;
        }

        public GraphDataHolder(int a, int NumOfValues) 
        {
            Data = new List<int>();
            this.a = a;
            this.b = 0;
            this.NumOfValues = NumOfValues;

            for (int i = 0; i < this.NumOfValues; i++)
                this.Data.Add(FirstEquasion(i));
            //this.Data.
            foreach (int i in this.Data)
                Console.WriteLine(i);
        }

        public GraphDataHolder(int a, int b, int NumOfValues)
        {
            Data = new List<int>();
            this.a = a;
            this.b = b;
            this.NumOfValues = NumOfValues;

            for (int i = 0; i < this.NumOfValues; i++)
                this.Data.Add(SecondEquasion(i));
            foreach (int i in this.Data)
                Console.WriteLine(i);
        }



        private int FirstEquasion(int i)
        {
            return this.a * (i * i);
        }
        
        private int SecondEquasion(int i)
        {
            return this.a * (this.b * i);
        }

        public Series GetData()
        {
            Series _Data = new Series();
            _Data.ChartType = SeriesChartType.Line;
            foreach (int i in this.Data)
                _Data.Points.AddY(i);
            return _Data;
        }
    }
}
