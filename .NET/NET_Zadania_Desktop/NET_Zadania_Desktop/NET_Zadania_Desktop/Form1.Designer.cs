namespace NET_Zadania_Desktop
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.option_Selector = new System.Windows.Forms.ComboBox();
            this.label_Info = new System.Windows.Forms.Label();
            this.textBox_Brand = new System.Windows.Forms.TextBox();
            this.textBox_ProductionYear = new System.Windows.Forms.TextBox();
            this.textBox_Model = new System.Windows.Forms.TextBox();
            this.Label_Brand = new System.Windows.Forms.Label();
            this.Label_Model = new System.Windows.Forms.Label();
            this.Label_ProductionYear = new System.Windows.Forms.Label();
            this.BaseOptionGroup = new System.Windows.Forms.GroupBox();
            this.AdditionalOptionGroup = new System.Windows.Forms.GroupBox();
            this.label_Option2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label_Option1 = new System.Windows.Forms.Label();
            this.btn_ShowProp = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Search = new System.Windows.Forms.Button();
            this.listBox_Cars = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.terrainCarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.carBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.carBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.BaseOptionGroup.SuspendLayout();
            this.AdditionalOptionGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.terrainCarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // option_Selector
            // 
            this.option_Selector.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.option_Selector.FormattingEnabled = true;
            this.option_Selector.Items.AddRange(new object[] {
            "Rodzinny",
            "Sportowy",
            "Terenowy"});
            this.option_Selector.Location = new System.Drawing.Point(194, 12);
            this.option_Selector.Name = "option_Selector";
            this.option_Selector.Size = new System.Drawing.Size(244, 26);
            this.option_Selector.TabIndex = 1;
            this.option_Selector.SelectedIndexChanged += new System.EventHandler(this.option_Selector_SelectedIndexChanged);
            // 
            // label_Info
            // 
            this.label_Info.AutoSize = true;
            this.label_Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_Info.Location = new System.Drawing.Point(8, 14);
            this.label_Info.Name = "label_Info";
            this.label_Info.Size = new System.Drawing.Size(180, 20);
            this.label_Info.TabIndex = 0;
            this.label_Info.Text = "Wybierz typ Samochodu";
            this.label_Info.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox_Brand
            // 
            this.textBox_Brand.Enabled = false;
            this.textBox_Brand.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_Brand.Location = new System.Drawing.Point(120, 16);
            this.textBox_Brand.Name = "textBox_Brand";
            this.textBox_Brand.Size = new System.Drawing.Size(306, 24);
            this.textBox_Brand.TabIndex = 3;
            // 
            // textBox_ProductionYear
            // 
            this.textBox_ProductionYear.Enabled = false;
            this.textBox_ProductionYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_ProductionYear.Location = new System.Drawing.Point(120, 73);
            this.textBox_ProductionYear.Name = "textBox_ProductionYear";
            this.textBox_ProductionYear.Size = new System.Drawing.Size(306, 24);
            this.textBox_ProductionYear.TabIndex = 8;
            // 
            // textBox_Model
            // 
            this.textBox_Model.Enabled = false;
            this.textBox_Model.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_Model.Location = new System.Drawing.Point(120, 43);
            this.textBox_Model.Name = "textBox_Model";
            this.textBox_Model.Size = new System.Drawing.Size(306, 24);
            this.textBox_Model.TabIndex = 6;
            // 
            // Label_Brand
            // 
            this.Label_Brand.AutoSize = true;
            this.Label_Brand.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label_Brand.Location = new System.Drawing.Point(11, 19);
            this.Label_Brand.Name = "Label_Brand";
            this.Label_Brand.Size = new System.Drawing.Size(50, 18);
            this.Label_Brand.TabIndex = 3;
            this.Label_Brand.Text = "Marka";
            this.Label_Brand.Click += new System.EventHandler(this.Label_Brand_Click);
            // 
            // Label_Model
            // 
            this.Label_Model.AutoSize = true;
            this.Label_Model.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label_Model.Location = new System.Drawing.Point(11, 49);
            this.Label_Model.Name = "Label_Model";
            this.Label_Model.Size = new System.Drawing.Size(49, 18);
            this.Label_Model.TabIndex = 5;
            this.Label_Model.Text = "Model";
            // 
            // Label_ProductionYear
            // 
            this.Label_ProductionYear.AutoSize = true;
            this.Label_ProductionYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label_ProductionYear.Location = new System.Drawing.Point(11, 79);
            this.Label_ProductionYear.Name = "Label_ProductionYear";
            this.Label_ProductionYear.Size = new System.Drawing.Size(102, 18);
            this.Label_ProductionYear.TabIndex = 7;
            this.Label_ProductionYear.Text = "Rok Produkcji";
            this.Label_ProductionYear.Click += new System.EventHandler(this.Label_ProductionYear_Click);
            // 
            // BaseOptionGroup
            // 
            this.BaseOptionGroup.Controls.Add(this.Label_ProductionYear);
            this.BaseOptionGroup.Controls.Add(this.textBox_ProductionYear);
            this.BaseOptionGroup.Controls.Add(this.textBox_Model);
            this.BaseOptionGroup.Controls.Add(this.Label_Model);
            this.BaseOptionGroup.Controls.Add(this.Label_Brand);
            this.BaseOptionGroup.Controls.Add(this.textBox_Brand);
            this.BaseOptionGroup.Location = new System.Drawing.Point(12, 44);
            this.BaseOptionGroup.Name = "BaseOptionGroup";
            this.BaseOptionGroup.Size = new System.Drawing.Size(432, 112);
            this.BaseOptionGroup.TabIndex = 2;
            this.BaseOptionGroup.TabStop = false;
            this.BaseOptionGroup.Text = "Podstawowe dane";
            // 
            // AdditionalOptionGroup
            // 
            this.AdditionalOptionGroup.Controls.Add(this.label_Option2);
            this.AdditionalOptionGroup.Controls.Add(this.textBox2);
            this.AdditionalOptionGroup.Controls.Add(this.textBox1);
            this.AdditionalOptionGroup.Controls.Add(this.label_Option1);
            this.AdditionalOptionGroup.Location = new System.Drawing.Point(12, 162);
            this.AdditionalOptionGroup.Name = "AdditionalOptionGroup";
            this.AdditionalOptionGroup.Size = new System.Drawing.Size(432, 76);
            this.AdditionalOptionGroup.TabIndex = 9;
            this.AdditionalOptionGroup.TabStop = false;
            this.AdditionalOptionGroup.Text = "Zaawansowane dane";
            // 
            // label_Option2
            // 
            this.label_Option2.AutoSize = true;
            this.label_Option2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_Option2.Location = new System.Drawing.Point(11, 43);
            this.label_Option2.Name = "label_Option2";
            this.label_Option2.Size = new System.Drawing.Size(64, 18);
            this.label_Option2.TabIndex = 12;
            this.label_Option2.Text = "Option 2";
            this.label_Option2.Click += new System.EventHandler(this.label_Option2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox2.Location = new System.Drawing.Point(182, 43);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(244, 24);
            this.textBox2.TabIndex = 13;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(182, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(244, 24);
            this.textBox1.TabIndex = 11;
            // 
            // label_Option1
            // 
            this.label_Option1.AutoSize = true;
            this.label_Option1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_Option1.Location = new System.Drawing.Point(11, 16);
            this.label_Option1.Name = "label_Option1";
            this.label_Option1.Size = new System.Drawing.Size(64, 18);
            this.label_Option1.TabIndex = 10;
            this.label_Option1.Text = "Option 1";
            // 
            // btn_ShowProp
            // 
            this.btn_ShowProp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_ShowProp.Location = new System.Drawing.Point(12, 244);
            this.btn_ShowProp.Name = "btn_ShowProp";
            this.btn_ShowProp.Size = new System.Drawing.Size(155, 36);
            this.btn_ShowProp.TabIndex = 14;
            this.btn_ShowProp.Text = "Pokaż Dane";
            this.btn_ShowProp.UseVisualStyleBackColor = true;
            this.btn_ShowProp.Click += new System.EventHandler(this.btn_ShowProp_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Enabled = false;
            this.btn_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Add.Location = new System.Drawing.Point(326, 244);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(118, 36);
            this.btn_Add.TabIndex = 16;
            this.btn_Add.Text = "Dodaj Pojazd";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Search
            // 
            this.btn_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Search.Location = new System.Drawing.Point(173, 244);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(147, 36);
            this.btn_Search.TabIndex = 15;
            this.btn_Search.Text = "Wyszukaj Pojazd";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // listBox_Cars
            // 
            this.listBox_Cars.FormattingEnabled = true;
            this.listBox_Cars.Location = new System.Drawing.Point(6, 19);
            this.listBox_Cars.Name = "listBox_Cars";
            this.listBox_Cars.Size = new System.Drawing.Size(407, 238);
            this.listBox_Cars.TabIndex = 17;
            this.listBox_Cars.SelectedIndexChanged += new System.EventHandler(this.listBox_Cars_SelectedIndexChanged);
            this.listBox_Cars.DoubleClick += new System.EventHandler(this.listBox_Cars_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox_Cars);
            this.groupBox1.Location = new System.Drawing.Point(450, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(419, 266);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Samochody w Komisie";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // terrainCarBindingSource
            // 
            this.terrainCarBindingSource.DataSource = typeof(NET_Zadania_Desktop.TerrainCar);
            // 
            // carBindingSource
            // 
            this.carBindingSource.DataSource = typeof(NET_Zadania_Desktop.Car);
            // 
            // carBindingSource1
            // 
            this.carBindingSource1.DataSource = typeof(NET_Zadania_Desktop.Car);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 291);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.btn_ShowProp);
            this.Controls.Add(this.AdditionalOptionGroup);
            this.Controls.Add(this.BaseOptionGroup);
            this.Controls.Add(this.label_Info);
            this.Controls.Add(this.option_Selector);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Komis Samochodowy";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.BaseOptionGroup.ResumeLayout(false);
            this.BaseOptionGroup.PerformLayout();
            this.AdditionalOptionGroup.ResumeLayout(false);
            this.AdditionalOptionGroup.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.terrainCarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox option_Selector;
        private System.Windows.Forms.Label label_Info;
        private System.Windows.Forms.TextBox textBox_Brand;
        private System.Windows.Forms.TextBox textBox_ProductionYear;
        private System.Windows.Forms.TextBox textBox_Model;
        private System.Windows.Forms.Label Label_Brand;
        private System.Windows.Forms.Label Label_Model;
        private System.Windows.Forms.Label Label_ProductionYear;
        private System.Windows.Forms.GroupBox BaseOptionGroup;
        private System.Windows.Forms.GroupBox AdditionalOptionGroup;
        private System.Windows.Forms.Label label_Option1;
        private System.Windows.Forms.Label label_Option2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_ShowProp;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.ListBox listBox_Cars;
        private System.Windows.Forms.BindingSource terrainCarBindingSource;
        private System.Windows.Forms.BindingSource carBindingSource;
        private System.Windows.Forms.BindingSource carBindingSource1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

