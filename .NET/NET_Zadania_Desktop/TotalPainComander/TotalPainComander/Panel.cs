using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


namespace TotalPainComander
{
    public partial class Panel : UserControl
    {
        string filePath;
        public Panel(string GroupName)
        {
            InitializeComponent();
            this.groupBox1.Text = GroupName;
            
        }

        private int GetDriveUsagePercentage(string driveLetter)
        {   
            DriveInfo driveInfo = new DriveInfo(driveLetter);
            
            if (driveInfo.IsReady)
            {
                double freeSpacePercentage = ((double)driveInfo.TotalFreeSpace / driveInfo.TotalSize) * 100;
                return (int)(100 - freeSpacePercentage);
            }
            else 
                return 0;
        }

        private double BytesToGigabytes(long bytes) => Math.Round((double)bytes / 1073741824, 2); // 1 gigabyte = 1024^3 bytes 

        private string GetDriveLetter(string Directory) => Directory[0].ToString();

        private string GetDiskData(string Directory)
        {
            string DriveLetter = GetDriveLetter(Directory);
            String Data;

            DriveInfo driveInfo = new DriveInfo(DriveLetter);
            if (driveInfo.IsReady)
                Data = $" Free  Space {BytesToGigabytes(driveInfo.TotalFreeSpace)}GB \n Total Space {BytesToGigabytes(driveInfo.TotalSize)}GB";
            else
                Data = "?/?";
            return Data;
        }

        private List<string> GetTxtFiles(string directoryPath)
        {
            List<string> txtFiles = new List<string>();

            try
            {
                // Check if the directory exists
                if (Directory.Exists(directoryPath))
                {
                    // Get all files in the directory with .txt extension
                    string[] files = Directory.GetFiles(directoryPath, "*.txt");

                    // Add each file to the list
                    foreach (string file in files)
                    {
                        txtFiles.Add(file);
                    }
                }
                else
                {
                    Console.WriteLine("Directory does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return txtFiles;
        }


        private void DisplayFirstFiveLines(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string[] lines = new string[5];
                    for (int i = 0; i < 5; i++)
                    {
                        lines[i] = reader.ReadLine();
                    }
                    string firstFiveLines = string.Join(Environment.NewLine, lines);
                    MessageBox.Show(firstFiveLines, "First Five Lines", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnn_GoInto_Click(object sender, EventArgs e)
        {
            using(FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select your Path Of Pain." })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    this.WindowFiles.Url = new Uri(fbd.SelectedPath);
                    this.textBox_Directory.Text = fbd.SelectedPath;
                    this.DiskUsageBar.Value = GetDriveUsagePercentage(GetDriveLetter(fbd.SelectedPath));
                    this.label_DiskSpace.Text = GetDiskData(fbd.SelectedPath);
                    this.filePath = fbd.SelectedPath;

                    if (GetTxtFiles(fbd.SelectedPath) != null)
                        this.comboBox1.Enabled = true;
                    else 
                        this.comboBox1.Enabled = false;

                    this.comboBox1.Items.Clear();

                    foreach(var File in GetTxtFiles(fbd.SelectedPath))
                        this.comboBox1.Items.Add(File);
                }
            }
            
        }

        private void tbn_GoBack_Click(object sender, EventArgs e)
        {
            if (this.WindowFiles.CanGoBack)
                this.WindowFiles.GoBack();
        }

        private void btn_GoDeep_Click(object sender, EventArgs e)
        {
            if (this.WindowFiles.CanGoForward)
                this.WindowFiles.GoForward();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisplayFirstFiveLines(filePath);
            
        }
    }
}
