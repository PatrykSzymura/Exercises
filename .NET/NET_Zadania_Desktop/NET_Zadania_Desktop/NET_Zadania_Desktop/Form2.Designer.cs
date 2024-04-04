namespace NET_Zadania_Desktop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.groupBox_Prop = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.textBox_Brand = new System.Windows.Forms.TextBox();
            this.Label_Brand = new System.Windows.Forms.Label();
            this.Label_Model = new System.Windows.Forms.Label();
            this.Label_ProductionYear = new System.Windows.Forms.Label();
            this.textBox_Model = new System.Windows.Forms.TextBox();
            this.textBox_ProductionYear = new System.Windows.Forms.TextBox();
            this.label_Option1 = new System.Windows.Forms.Label();
            this.label_Option2 = new System.Windows.Forms.Label();
            this.textBox_Option1 = new System.Windows.Forms.TextBox();
            this.textBox_Option2 = new System.Windows.Forms.TextBox();
            this.button_Delete = new System.Windows.Forms.Button();
            this.groupBox_Prop.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Prop
            // 
            this.groupBox_Prop.Controls.Add(this.textBox_Option2);
            this.groupBox_Prop.Controls.Add(this.textBox_Option1);
            this.groupBox_Prop.Controls.Add(this.label_Option2);
            this.groupBox_Prop.Controls.Add(this.label_Option1);
            this.groupBox_Prop.Controls.Add(this.textBox_ProductionYear);
            this.groupBox_Prop.Controls.Add(this.textBox_Model);
            this.groupBox_Prop.Controls.Add(this.Label_ProductionYear);
            this.groupBox_Prop.Controls.Add(this.Label_Model);
            this.groupBox_Prop.Controls.Add(this.Label_Brand);
            this.groupBox_Prop.Controls.Add(this.textBox_Brand);
            this.groupBox_Prop.Location = new System.Drawing.Point(12, 12);
            this.groupBox_Prop.Name = "groupBox_Prop";
            this.groupBox_Prop.Size = new System.Drawing.Size(384, 152);
            this.groupBox_Prop.TabIndex = 0;
            this.groupBox_Prop.TabStop = false;
            this.groupBox_Prop.Text = " Properties";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_Delete);
            this.groupBox3.Controls.Add(this.button_Exit);
            this.groupBox3.Controls.Add(this.button_Save);
            this.groupBox3.Location = new System.Drawing.Point(12, 170);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(383, 63);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Actions";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(6, 19);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(118, 31);
            this.button_Save.TabIndex = 12;
            this.button_Save.Text = "Zapisz zmiany";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.Location = new System.Drawing.Point(252, 19);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(125, 31);
            this.button_Exit.TabIndex = 14;
            this.button_Exit.Text = "Wyjdź bez zmian";
            this.button_Exit.UseVisualStyleBackColor = true;
            // 
            // textBox_Brand
            // 
            this.textBox_Brand.Location = new System.Drawing.Point(177, 14);
            this.textBox_Brand.Name = "textBox_Brand";
            this.textBox_Brand.Size = new System.Drawing.Size(201, 20);
            this.textBox_Brand.TabIndex = 2;
            this.textBox_Brand.TextChanged += new System.EventHandler(this.textBox_Brand_TextChanged);
            // 
            // Label_Brand
            // 
            this.Label_Brand.AutoSize = true;
            this.Label_Brand.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label_Brand.Location = new System.Drawing.Point(6, 16);
            this.Label_Brand.Name = "Label_Brand";
            this.Label_Brand.Size = new System.Drawing.Size(50, 18);
            this.Label_Brand.TabIndex = 1;
            this.Label_Brand.Text = "Marka";
            this.Label_Brand.Click += new System.EventHandler(this.Label_Brand_Click);
            // 
            // Label_Model
            // 
            this.Label_Model.AutoSize = true;
            this.Label_Model.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label_Model.Location = new System.Drawing.Point(6, 42);
            this.Label_Model.Name = "Label_Model";
            this.Label_Model.Size = new System.Drawing.Size(49, 18);
            this.Label_Model.TabIndex = 3;
            this.Label_Model.Text = "Model";
            this.Label_Model.Click += new System.EventHandler(this.Label_Model_Click);
            // 
            // Label_ProductionYear
            // 
            this.Label_ProductionYear.AutoSize = true;
            this.Label_ProductionYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label_ProductionYear.Location = new System.Drawing.Point(6, 68);
            this.Label_ProductionYear.Name = "Label_ProductionYear";
            this.Label_ProductionYear.Size = new System.Drawing.Size(102, 18);
            this.Label_ProductionYear.TabIndex = 5;
            this.Label_ProductionYear.Text = "Rok Produkcji";
            this.Label_ProductionYear.Click += new System.EventHandler(this.Label_ProductionYear_Click);
            // 
            // textBox_Model
            // 
            this.textBox_Model.Location = new System.Drawing.Point(177, 40);
            this.textBox_Model.Name = "textBox_Model";
            this.textBox_Model.Size = new System.Drawing.Size(201, 20);
            this.textBox_Model.TabIndex = 4;
            // 
            // textBox_ProductionYear
            // 
            this.textBox_ProductionYear.Location = new System.Drawing.Point(177, 66);
            this.textBox_ProductionYear.Name = "textBox_ProductionYear";
            this.textBox_ProductionYear.Size = new System.Drawing.Size(201, 20);
            this.textBox_ProductionYear.TabIndex = 6;
            // 
            // label_Option1
            // 
            this.label_Option1.AutoSize = true;
            this.label_Option1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_Option1.Location = new System.Drawing.Point(6, 94);
            this.label_Option1.Name = "label_Option1";
            this.label_Option1.Size = new System.Drawing.Size(64, 18);
            this.label_Option1.TabIndex = 7;
            this.label_Option1.Text = "Option 1";
            // 
            // label_Option2
            // 
            this.label_Option2.AutoSize = true;
            this.label_Option2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_Option2.Location = new System.Drawing.Point(6, 120);
            this.label_Option2.Name = "label_Option2";
            this.label_Option2.Size = new System.Drawing.Size(64, 18);
            this.label_Option2.TabIndex = 9;
            this.label_Option2.Text = "Option 2";
            // 
            // textBox_Option1
            // 
            this.textBox_Option1.Location = new System.Drawing.Point(177, 92);
            this.textBox_Option1.Name = "textBox_Option1";
            this.textBox_Option1.Size = new System.Drawing.Size(201, 20);
            this.textBox_Option1.TabIndex = 8;
            // 
            // textBox_Option2
            // 
            this.textBox_Option2.Location = new System.Drawing.Point(177, 118);
            this.textBox_Option2.Name = "textBox_Option2";
            this.textBox_Option2.Size = new System.Drawing.Size(201, 20);
            this.textBox_Option2.TabIndex = 10;
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(130, 19);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(116, 31);
            this.button_Delete.TabIndex = 13;
            this.button_Delete.Text = "Usuń";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 245);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox_Prop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Informations";
            this.groupBox_Prop.ResumeLayout(false);
            this.groupBox_Prop.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Prop;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.TextBox textBox_Brand;
        private System.Windows.Forms.Label Label_Brand;
        private System.Windows.Forms.Label Label_Model;
        private System.Windows.Forms.TextBox textBox_ProductionYear;
        private System.Windows.Forms.TextBox textBox_Model;
        private System.Windows.Forms.Label Label_ProductionYear;
        private System.Windows.Forms.Label label_Option1;
        private System.Windows.Forms.Label label_Option2;
        private System.Windows.Forms.TextBox textBox_Option2;
        private System.Windows.Forms.TextBox textBox_Option1;
        private System.Windows.Forms.Button button_Delete;
    }
}