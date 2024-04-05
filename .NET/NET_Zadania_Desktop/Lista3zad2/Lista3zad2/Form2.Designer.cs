namespace Lista3zad2
{
    partial class Form2
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
            this.groupBox_Object = new System.Windows.Forms.GroupBox();
            this.listBox_Object = new System.Windows.Forms.ListBox();
            this.groupBox_Buttons = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox_Object.SuspendLayout();
            this.groupBox_Buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Object
            // 
            this.groupBox_Object.Controls.Add(this.listBox_Object);
            this.groupBox_Object.Location = new System.Drawing.Point(17, 10);
            this.groupBox_Object.Name = "groupBox_Object";
            this.groupBox_Object.Size = new System.Drawing.Size(370, 552);
            this.groupBox_Object.TabIndex = 0;
            this.groupBox_Object.TabStop = false;
            this.groupBox_Object.Text = "groupBox_Object";
            // 
            // listBox_Object
            // 
            this.listBox_Object.FormattingEnabled = true;
            this.listBox_Object.Location = new System.Drawing.Point(6, 19);
            this.listBox_Object.Name = "listBox_Object";
            this.listBox_Object.Size = new System.Drawing.Size(358, 524);
            this.listBox_Object.TabIndex = 0;
            this.listBox_Object.SelectedIndexChanged += new System.EventHandler(this.listBox_Object_SelectedIndexChanged);
            // 
            // groupBox_Buttons
            // 
            this.groupBox_Buttons.Controls.Add(this.button3);
            this.groupBox_Buttons.Controls.Add(this.button2);
            this.groupBox_Buttons.Controls.Add(this.button1);
            this.groupBox_Buttons.Location = new System.Drawing.Point(393, 10);
            this.groupBox_Buttons.Name = "groupBox_Buttons";
            this.groupBox_Buttons.Size = new System.Drawing.Size(161, 551);
            this.groupBox_Buttons.TabIndex = 1;
            this.groupBox_Buttons.TabStop = false;
            this.groupBox_Buttons.Text = "Buttons";
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(6, 123);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(149, 46);
            this.button3.TabIndex = 2;
            this.button3.Text = "Usun";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(6, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 46);
            this.button2.TabIndex = 1;
            this.button2.Text = "Modyfikuj";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "Dodaj Nowy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 574);
            this.Controls.Add(this.groupBox_Buttons);
            this.Controls.Add(this.groupBox_Object);
            this.Name = "Form2";
            this.Text = "Object";
            this.groupBox_Object.ResumeLayout(false);
            this.groupBox_Buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Object;
        private System.Windows.Forms.ListBox listBox_Object;
        private System.Windows.Forms.GroupBox groupBox_Buttons;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}