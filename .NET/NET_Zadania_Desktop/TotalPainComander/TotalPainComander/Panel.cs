using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TotalPainComander
{
    public partial class Panel : UserControl
    {
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
                }
            }
            
        }

        private void tbn_GoBack_Click(object sender, EventArgs e)
        {
            if ( this.WindowFiles.CanGoBack)
            {
                this.WindowFiles.GoBack();
            }
        }

        private void btn_GoDeep_Click(object sender, EventArgs e)
        {
            if (this.WindowFiles.CanGoForward)
            {
                this.WindowFiles.GoForward();
            }
        }
    }
}
