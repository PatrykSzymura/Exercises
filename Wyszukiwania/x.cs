using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PiComparisonApp
{
    public partial class MainForm : Form
    {
        private List<double> simulatedPiData;
        private List<double> tabularPiData;

        public MainForm()
        {
            InitializeComponent();
        }

        private void GenerateDataButton_Click(object sender, EventArgs e)
        {
            int numMeasurements = (int)NumMeasurementsNumericUpDown.Value;

            simulatedPiData = GenerateSimulatedPiData(numMeasurements);
            tabularPiData = GenerateTabularPiData(numMeasurements);

            PlotData();
        }

        private List<double> GenerateSimulatedPiData(int numMeasurements)
        {
            List<double> measurements = new List<double>();
            double currentPiEstimate = 0;

            Random random = new Random();
            for (int i = 0; i < numMeasurements; i++)
            {
                currentPiEstimate += random.NextDouble() * 2 - 1; // losowa wartość z zakresu [-1, 1]
                measurements.Add(currentPiEstimate);
            }

            return measurements;
        }

        private List<double> GenerateTabularPiData(int numMeasurements)
        {
            List<double> measurements = new List<double>();
            for (int i = 0; i < numMeasurements; i++)
            {
                measurements.Add(Math.PI);
            }

            return measurements;
        }

        private void PlotData()
        {
            Chart.Series["SimulatedData"].Points.Clear();
            Chart.Series["TabularData"].Points.Clear();
            Chart.Series["RealValue"].Points.Clear();

            for (int i = 0; i < simulatedPiData.Count; i++)
            {
                Chart.Series["SimulatedData"].Points.AddY(simulatedPiData[i]);
                Chart.Series["TabularData"].Points.AddY(tabularPiData[i]);
                Chart.Series["RealValue"].Points.AddY(Math.PI);
            }
        }
    }
}