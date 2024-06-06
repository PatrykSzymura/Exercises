namespace Lista_8
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
            this.label1 = new System.Windows.Forms.Label();
            this.counter3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_test = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.counter6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.counter5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.counter4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.list_numbers = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "3-match";
            // 
            // counter3
            // 
            this.counter3.AutoSize = true;
            this.counter3.Location = new System.Drawing.Point(57, 16);
            this.counter3.Name = "counter3";
            this.counter3.Size = new System.Drawing.Size(13, 13);
            this.counter3.TabIndex = 1;
            this.counter3.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Controls.Add(this.search);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.counter6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.counter5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.counter4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.counter3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 205);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.btn_test, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_stop, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_start, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 124);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(243, 75);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // btn_test
            // 
            this.btn_test.Location = new System.Drawing.Point(164, 3);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(74, 69);
            this.btn_test.TabIndex = 5;
            this.btn_test.Text = "Test";
            this.btn_test.UseVisualStyleBackColor = true;
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(83, 3);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(74, 69);
            this.btn_stop.TabIndex = 4;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(3, 3);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(74, 69);
            this.btn_start.TabIndex = 3;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            // 
            // search
            // 
            this.search.AutoSize = true;
            this.search.Location = new System.Drawing.Point(9, 89);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(35, 13);
            this.search.TabIndex = 8;
            this.search.Text = "label3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "6-match";
            // 
            // counter6
            // 
            this.counter6.AutoSize = true;
            this.counter6.Location = new System.Drawing.Point(57, 55);
            this.counter6.Name = "counter6";
            this.counter6.Size = new System.Drawing.Size(13, 13);
            this.counter6.TabIndex = 7;
            this.counter6.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "5-match";
            // 
            // counter5
            // 
            this.counter5.AutoSize = true;
            this.counter5.Location = new System.Drawing.Point(57, 42);
            this.counter5.Name = "counter5";
            this.counter5.Size = new System.Drawing.Size(13, 13);
            this.counter5.TabIndex = 5;
            this.counter5.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "4-match";
            // 
            // counter4
            // 
            this.counter4.AutoSize = true;
            this.counter4.Location = new System.Drawing.Point(57, 29);
            this.counter4.Name = "counter4";
            this.counter4.Size = new System.Drawing.Size(13, 13);
            this.counter4.TabIndex = 3;
            this.counter4.Text = "0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.list_numbers);
            this.groupBox2.Location = new System.Drawing.Point(268, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 426);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // list_numbers
            // 
            this.list_numbers.FormattingEnabled = true;
            this.list_numbers.Location = new System.Drawing.Point(6, 16);
            this.list_numbers.Name = "list_numbers";
            this.list_numbers.Size = new System.Drawing.Size(288, 407);
            this.list_numbers.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label counter3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label counter5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label counter4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label counter6;
        private System.Windows.Forms.Label search;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox list_numbers;
    }
}

