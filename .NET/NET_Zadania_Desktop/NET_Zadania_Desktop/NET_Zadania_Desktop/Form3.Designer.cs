namespace NET_Zadania_Desktop
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.groupBox_Search = new System.Windows.Forms.GroupBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.textBox_Search = new System.Windows.Forms.TextBox();
            this.listBox_Search_Ress = new System.Windows.Forms.ListBox();
            this.groupBox_Search.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Search
            // 
            this.groupBox_Search.Controls.Add(this.btn_Search);
            this.groupBox_Search.Controls.Add(this.textBox_Search);
            this.groupBox_Search.Controls.Add(this.listBox_Search_Ress);
            this.groupBox_Search.Location = new System.Drawing.Point(11, 10);
            this.groupBox_Search.Name = "groupBox_Search";
            this.groupBox_Search.Size = new System.Drawing.Size(398, 430);
            this.groupBox_Search.TabIndex = 0;
            this.groupBox_Search.TabStop = false;
            this.groupBox_Search.Text = "Wyszukiwanie";
            // 
            // btn_Search
            // 
            this.btn_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Search.Location = new System.Drawing.Point(355, 19);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(37, 26);
            this.btn_Search.TabIndex = 2;
            this.btn_Search.Text = "🔍";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // textBox_Search
            // 
            this.textBox_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_Search.Location = new System.Drawing.Point(6, 19);
            this.textBox_Search.Name = "textBox_Search";
            this.textBox_Search.Size = new System.Drawing.Size(343, 26);
            this.textBox_Search.TabIndex = 1;
            // 
            // listBox_Search_Ress
            // 
            this.listBox_Search_Ress.FormattingEnabled = true;
            this.listBox_Search_Ress.Location = new System.Drawing.Point(6, 58);
            this.listBox_Search_Ress.Name = "listBox_Search_Ress";
            this.listBox_Search_Ress.Size = new System.Drawing.Size(386, 368);
            this.listBox_Search_Ress.TabIndex = 3;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 450);
            this.Controls.Add(this.groupBox_Search);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.Text = "Wyszukiwanie";
            this.groupBox_Search.ResumeLayout(false);
            this.groupBox_Search.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Search;
        private System.Windows.Forms.ListBox listBox_Search_Ress;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.TextBox textBox_Search;
    }
}