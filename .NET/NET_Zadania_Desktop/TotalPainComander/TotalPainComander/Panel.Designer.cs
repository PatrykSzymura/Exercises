namespace TotalPainComander
{
    partial class Panel
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_Directory = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label_DiskSpace = new System.Windows.Forms.Label();
            this.DiskUsageBar = new System.Windows.Forms.ProgressBar();
            this.WindowFiles = new System.Windows.Forms.WebBrowser();
            this.btn_GoDeep = new System.Windows.Forms.Button();
            this.textBox_Directory = new System.Windows.Forms.TextBox();
            this.btnn_GoInto = new System.Windows.Forms.Button();
            this.tbn_GoBack = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Directory
            // 
            this.label_Directory.AutoSize = true;
            this.label_Directory.Location = new System.Drawing.Point(114, 24);
            this.label_Directory.Name = "label_Directory";
            this.label_Directory.Size = new System.Drawing.Size(49, 13);
            this.label_Directory.TabIndex = 0;
            this.label_Directory.Text = "Directory";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label_DiskSpace);
            this.groupBox1.Controls.Add(this.DiskUsageBar);
            this.groupBox1.Controls.Add(this.WindowFiles);
            this.groupBox1.Controls.Add(this.btn_GoDeep);
            this.groupBox1.Controls.Add(this.textBox_Directory);
            this.groupBox1.Controls.Add(this.btnn_GoInto);
            this.groupBox1.Controls.Add(this.tbn_GoBack);
            this.groupBox1.Controls.Add(this.label_Directory);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(644, 699);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(444, 642);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Preview";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(60, 642);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(378, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // label_DiskSpace
            // 
            this.label_DiskSpace.AutoSize = true;
            this.label_DiskSpace.Location = new System.Drawing.Point(6, 671);
            this.label_DiskSpace.Name = "label_DiskSpace";
            this.label_DiskSpace.Size = new System.Drawing.Size(66, 13);
            this.label_DiskSpace.TabIndex = 8;
            this.label_DiskSpace.Text = "CurrentDrive";
            // 
            // DiskUsageBar
            // 
            this.DiskUsageBar.Location = new System.Drawing.Point(117, 671);
            this.DiskUsageBar.Name = "DiskUsageBar";
            this.DiskUsageBar.Size = new System.Drawing.Size(521, 19);
            this.DiskUsageBar.Step = 100;
            this.DiskUsageBar.TabIndex = 7;
            this.DiskUsageBar.Value = 1;
            // 
            // WindowFiles
            // 
            this.WindowFiles.Location = new System.Drawing.Point(6, 48);
            this.WindowFiles.MinimumSize = new System.Drawing.Size(20, 20);
            this.WindowFiles.Name = "WindowFiles";
            this.WindowFiles.Size = new System.Drawing.Size(632, 590);
            this.WindowFiles.TabIndex = 6;
            // 
            // btn_GoDeep
            // 
            this.btn_GoDeep.Location = new System.Drawing.Point(60, 19);
            this.btn_GoDeep.Name = "btn_GoDeep";
            this.btn_GoDeep.Size = new System.Drawing.Size(48, 23);
            this.btn_GoDeep.TabIndex = 5;
            this.btn_GoDeep.Text = ">";
            this.btn_GoDeep.UseVisualStyleBackColor = true;
            this.btn_GoDeep.Click += new System.EventHandler(this.btn_GoDeep_Click);
            // 
            // textBox_Directory
            // 
            this.textBox_Directory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_Directory.Location = new System.Drawing.Point(169, 19);
            this.textBox_Directory.Name = "textBox_Directory";
            this.textBox_Directory.Size = new System.Drawing.Size(412, 22);
            this.textBox_Directory.TabIndex = 4;
            // 
            // btnn_GoInto
            // 
            this.btnn_GoInto.Location = new System.Drawing.Point(587, 18);
            this.btnn_GoInto.Name = "btnn_GoInto";
            this.btnn_GoInto.Size = new System.Drawing.Size(51, 23);
            this.btnn_GoInto.TabIndex = 3;
            this.btnn_GoInto.Text = "Go";
            this.btnn_GoInto.UseVisualStyleBackColor = true;
            this.btnn_GoInto.Click += new System.EventHandler(this.btnn_GoInto_Click);
            // 
            // tbn_GoBack
            // 
            this.tbn_GoBack.Location = new System.Drawing.Point(6, 19);
            this.tbn_GoBack.Name = "tbn_GoBack";
            this.tbn_GoBack.Size = new System.Drawing.Size(48, 23);
            this.tbn_GoBack.TabIndex = 1;
            this.tbn_GoBack.Text = "<";
            this.tbn_GoBack.UseVisualStyleBackColor = true;
            this.tbn_GoBack.Click += new System.EventHandler(this.tbn_GoBack_Click);
            // 
            // Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "Panel";
            this.Size = new System.Drawing.Size(650, 705);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_Directory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_Directory;
        private System.Windows.Forms.Button btnn_GoInto;
        private System.Windows.Forms.Button tbn_GoBack;
        private System.Windows.Forms.Button btn_GoDeep;
        private System.Windows.Forms.WebBrowser WindowFiles;
        private System.Windows.Forms.Label label_DiskSpace;
        private System.Windows.Forms.ProgressBar DiskUsageBar;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
    }
}
