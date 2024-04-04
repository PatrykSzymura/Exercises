namespace Lista3zad2
{
    partial class Form1
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

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox_Options = new System.Windows.Forms.GroupBox();
            this.btn_Point = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox_Options.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Options
            // 
            this.groupBox_Options.Controls.Add(this.button4);
            this.groupBox_Options.Controls.Add(this.button3);
            this.groupBox_Options.Controls.Add(this.button2);
            this.groupBox_Options.Controls.Add(this.button1);
            this.groupBox_Options.Controls.Add(this.btn_Point);
            this.groupBox_Options.Location = new System.Drawing.Point(12, 12);
            this.groupBox_Options.Name = "groupBox_Options";
            this.groupBox_Options.Size = new System.Drawing.Size(293, 374);
            this.groupBox_Options.TabIndex = 0;
            this.groupBox_Options.TabStop = false;
            this.groupBox_Options.Text = "Choose Figure";
            // 
            // btn_Point
            // 
            this.btn_Point.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Point.Location = new System.Drawing.Point(6, 19);
            this.btn_Point.Name = "btn_Point";
            this.btn_Point.Size = new System.Drawing.Size(281, 46);
            this.btn_Point.TabIndex = 0;
            this.btn_Point.Text = "Point";
            this.btn_Point.UseVisualStyleBackColor = true;
            this.btn_Point.Click += new System.EventHandler(this.btn_Point_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(311, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 373);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Figury";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(384, 342);
            this.listBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(6, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(281, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "Kolo";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(6, 123);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(281, 46);
            this.button2.TabIndex = 2;
            this.button2.Text = "Trojkat";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button3.Location = new System.Drawing.Point(6, 175);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(281, 46);
            this.button3.TabIndex = 3;
            this.button3.Text = "Wielobok";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button4.Location = new System.Drawing.Point(6, 227);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(281, 46);
            this.button4.TabIndex = 4;
            this.button4.Text = "Edytuj";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 395);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_Options);
            this.Name = "Form1";
            this.Text = "Choose Figure";
            this.groupBox_Options.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Options;
        private System.Windows.Forms.Button btn_Point;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}

