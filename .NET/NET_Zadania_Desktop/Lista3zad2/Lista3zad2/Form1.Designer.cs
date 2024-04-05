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
            this.button_Polygon = new System.Windows.Forms.Button();
            this.button_Triangle = new System.Windows.Forms.Button();
            this.button_Circle = new System.Windows.Forms.Button();
            this.btn_Point = new System.Windows.Forms.Button();
            this.groupBox_Options.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Options
            // 
            this.groupBox_Options.Controls.Add(this.button_Polygon);
            this.groupBox_Options.Controls.Add(this.button_Triangle);
            this.groupBox_Options.Controls.Add(this.button_Circle);
            this.groupBox_Options.Controls.Add(this.btn_Point);
            this.groupBox_Options.Location = new System.Drawing.Point(12, 12);
            this.groupBox_Options.Name = "groupBox_Options";
            this.groupBox_Options.Size = new System.Drawing.Size(293, 230);
            this.groupBox_Options.TabIndex = 0;
            this.groupBox_Options.TabStop = false;
            this.groupBox_Options.Text = "Choose Figure";
            // 
            // button_Polygon
            // 
            this.button_Polygon.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_Polygon.Location = new System.Drawing.Point(6, 175);
            this.button_Polygon.Name = "button_Polygon";
            this.button_Polygon.Size = new System.Drawing.Size(281, 46);
            this.button_Polygon.TabIndex = 3;
            this.button_Polygon.Text = "Wielobok";
            this.button_Polygon.UseVisualStyleBackColor = true;
            this.button_Polygon.Click += new System.EventHandler(this.button_Polygon_Click);
            // 
            // button_Triangle
            // 
            this.button_Triangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_Triangle.Location = new System.Drawing.Point(6, 123);
            this.button_Triangle.Name = "button_Triangle";
            this.button_Triangle.Size = new System.Drawing.Size(281, 46);
            this.button_Triangle.TabIndex = 2;
            this.button_Triangle.Text = "Trojkat";
            this.button_Triangle.UseVisualStyleBackColor = true;
            this.button_Triangle.Click += new System.EventHandler(this.button_Triangle_Click);
            // 
            // button_Circle
            // 
            this.button_Circle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_Circle.Location = new System.Drawing.Point(6, 71);
            this.button_Circle.Name = "button_Circle";
            this.button_Circle.Size = new System.Drawing.Size(281, 46);
            this.button_Circle.TabIndex = 1;
            this.button_Circle.Text = "Kolo";
            this.button_Circle.UseVisualStyleBackColor = true;
            this.button_Circle.Click += new System.EventHandler(this.button_Circle_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 254);
            this.Controls.Add(this.groupBox_Options);
            this.Name = "Form1";
            this.Text = "Choose Figure";
            this.groupBox_Options.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Options;
        private System.Windows.Forms.Button btn_Point;
        private System.Windows.Forms.Button button_Polygon;
        private System.Windows.Forms.Button button_Triangle;
        private System.Windows.Forms.Button button_Circle;
    }
}

