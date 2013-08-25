namespace WindowsFormsApplication1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonCRDS = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.RegRamanlabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numberOfColumns = new System.Windows.Forms.NumericUpDown();
            this.CRDSopenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.WLMopenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.savePatched = new System.Windows.Forms.SaveFileDialog();
            this.valueToAddUpDown = new System.Windows.Forms.NumericUpDown();
            this.ramanShiftUpDown = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numberOfShotsUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.patchButton = new System.Windows.Forms.Button();
            this.cutWLMpoints = new System.Windows.Forms.CheckBox();
            this.CalcRamanShift = new System.Windows.Forms.CheckBox();
            this.TempLabel = new System.Windows.Forms.Label();
            this.PressureLabel = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape3 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.TemperatureUpDown = new System.Windows.Forms.NumericUpDown();
            this.PressureUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueToAddUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ramanShiftUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfShotsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TemperatureUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCRDS
            // 
            this.buttonCRDS.Location = new System.Drawing.Point(174, 20);
            this.buttonCRDS.Name = "buttonCRDS";
            this.buttonCRDS.Size = new System.Drawing.Size(75, 23);
            this.buttonCRDS.TabIndex = 1;
            this.buttonCRDS.Text = "Browse";
            this.buttonCRDS.UseVisualStyleBackColor = true;
            this.buttonCRDS.Click += new System.EventHandler(this.buttonCRDS_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(174, 66);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Browse";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Value to Add";
            // 
            // RegRamanlabel
            // 
            this.RegRamanlabel.AutoSize = true;
            this.RegRamanlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegRamanlabel.Location = new System.Drawing.Point(12, 149);
            this.RegRamanlabel.Name = "RegRamanlabel";
            this.RegRamanlabel.Size = new System.Drawing.Size(98, 20);
            this.RegRamanlabel.TabIndex = 10;
            this.RegRamanlabel.Text = "Raman Shift";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Open CRDS File";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Open WLM File";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Number of Columns";
            // 
            // numberOfColumns
            // 
            this.numberOfColumns.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfColumns.Location = new System.Drawing.Point(174, 262);
            this.numberOfColumns.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numberOfColumns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberOfColumns.Name = "numberOfColumns";
            this.numberOfColumns.Size = new System.Drawing.Size(88, 23);
            this.numberOfColumns.TabIndex = 14;
            this.numberOfColumns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numberOfColumns.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numberOfColumns.ValueChanged += new System.EventHandler(this.numberOfColumns_ValueChanged);
            // 
            // CRDSopenFileDialog
            // 
            this.CRDSopenFileDialog.FileName = "openFileDialog1";
            // 
            // WLMopenFileDialog
            // 
            this.WLMopenFileDialog.FileName = "openFileDialog2";
            // 
            // valueToAddUpDown
            // 
            this.valueToAddUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueToAddUpDown.Location = new System.Drawing.Point(143, 111);
            this.valueToAddUpDown.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.valueToAddUpDown.Name = "valueToAddUpDown";
            this.valueToAddUpDown.Size = new System.Drawing.Size(120, 23);
            this.valueToAddUpDown.TabIndex = 17;
            this.valueToAddUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.valueToAddUpDown.ValueChanged += new System.EventHandler(this.valueToAddUpDown_ValueChanged);
            // 
            // ramanShiftUpDown
            // 
            this.ramanShiftUpDown.DecimalPlaces = 5;
            this.ramanShiftUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ramanShiftUpDown.Location = new System.Drawing.Point(143, 146);
            this.ramanShiftUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ramanShiftUpDown.Name = "ramanShiftUpDown";
            this.ramanShiftUpDown.Size = new System.Drawing.Size(120, 23);
            this.ramanShiftUpDown.TabIndex = 18;
            this.ramanShiftUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ramanShiftUpDown.Value = new decimal(new int[] {
            41552500,
            0,
            0,
            262144});
            this.ramanShiftUpDown.ValueChanged += new System.EventHandler(this.ramanShiftUpDown_ValueChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(12, 320);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(155, 24);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "Patch Segments?";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // numberOfShotsUpDown
            // 
            this.numberOfShotsUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfShotsUpDown.Location = new System.Drawing.Point(174, 291);
            this.numberOfShotsUpDown.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numberOfShotsUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberOfShotsUpDown.Name = "numberOfShotsUpDown";
            this.numberOfShotsUpDown.Size = new System.Drawing.Size(88, 23);
            this.numberOfShotsUpDown.TabIndex = 22;
            this.numberOfShotsUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numberOfShotsUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numberOfShotsUpDown.ValueChanged += new System.EventHandler(this.numberOfShotsUpDown_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 294);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Number of Shots";
            // 
            // patchButton
            // 
            this.patchButton.AutoSize = true;
            this.patchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patchButton.Location = new System.Drawing.Point(12, 384);
            this.patchButton.Name = "patchButton";
            this.patchButton.Size = new System.Drawing.Size(251, 40);
            this.patchButton.TabIndex = 8;
            this.patchButton.Text = "Patch and Save";
            this.patchButton.UseVisualStyleBackColor = true;
            this.patchButton.Click += new System.EventHandler(this.patchButton_Click);
            // 
            // cutWLMpoints
            // 
            this.cutWLMpoints.AutoSize = true;
            this.cutWLMpoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cutWLMpoints.Location = new System.Drawing.Point(12, 350);
            this.cutWLMpoints.Name = "cutWLMpoints";
            this.cutWLMpoints.Size = new System.Drawing.Size(146, 24);
            this.cutWLMpoints.TabIndex = 23;
            this.cutWLMpoints.Text = "Cut WLM zeros?";
            this.cutWLMpoints.UseVisualStyleBackColor = true;
            // 
            // CalcRamanShift
            // 
            this.CalcRamanShift.AutoSize = true;
            this.CalcRamanShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CalcRamanShift.Location = new System.Drawing.Point(16, 177);
            this.CalcRamanShift.Name = "CalcRamanShift";
            this.CalcRamanShift.Size = new System.Drawing.Size(165, 24);
            this.CalcRamanShift.TabIndex = 24;
            this.CalcRamanShift.Text = "Calculate H2 Shift?";
            this.CalcRamanShift.UseVisualStyleBackColor = true;
            this.CalcRamanShift.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // TempLabel
            // 
            this.TempLabel.AutoSize = true;
            this.TempLabel.Enabled = false;
            this.TempLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TempLabel.Location = new System.Drawing.Point(12, 204);
            this.TempLabel.Name = "TempLabel";
            this.TempLabel.Size = new System.Drawing.Size(42, 20);
            this.TempLabel.TabIndex = 25;
            this.TempLabel.Text = "T (K)";
            // 
            // PressureLabel
            // 
            this.PressureLabel.AutoSize = true;
            this.PressureLabel.Enabled = false;
            this.PressureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PressureLabel.Location = new System.Drawing.Point(12, 233);
            this.PressureLabel.Name = "PressureLabel";
            this.PressureLabel.Size = new System.Drawing.Size(113, 20);
            this.PressureLabel.TabIndex = 26;
            this.PressureLabel.Text = "Pressure (atm)";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape3,
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(275, 436);
            this.shapeContainer1.TabIndex = 27;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape3
            // 
            this.lineShape3.Name = "lineShape3";
            this.lineShape3.X1 = 9;
            this.lineShape3.X2 = 261;
            this.lineShape3.Y1 = 319;
            this.lineShape3.Y2 = 319;
            // 
            // lineShape2
            // 
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 11;
            this.lineShape2.X2 = 263;
            this.lineShape2.Y1 = 174;
            this.lineShape2.Y2 = 174;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 9;
            this.lineShape1.X2 = 261;
            this.lineShape1.Y1 = 257;
            this.lineShape1.Y2 = 257;
            // 
            // TemperatureUpDown
            // 
            this.TemperatureUpDown.DecimalPlaces = 1;
            this.TemperatureUpDown.Enabled = false;
            this.TemperatureUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TemperatureUpDown.Location = new System.Drawing.Point(174, 202);
            this.TemperatureUpDown.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.TemperatureUpDown.Name = "TemperatureUpDown";
            this.TemperatureUpDown.Size = new System.Drawing.Size(90, 22);
            this.TemperatureUpDown.TabIndex = 28;
            this.TemperatureUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TemperatureUpDown.Value = new decimal(new int[] {
            298,
            0,
            0,
            0});
            // 
            // PressureUpDown
            // 
            this.PressureUpDown.DecimalPlaces = 1;
            this.PressureUpDown.Enabled = false;
            this.PressureUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PressureUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.PressureUpDown.Location = new System.Drawing.Point(174, 230);
            this.PressureUpDown.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.PressureUpDown.Name = "PressureUpDown";
            this.PressureUpDown.Size = new System.Drawing.Size(90, 22);
            this.PressureUpDown.TabIndex = 29;
            this.PressureUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PressureUpDown.Value = new decimal(new int[] {
            145,
            0,
            0,
            65536});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 436);
            this.Controls.Add(this.PressureUpDown);
            this.Controls.Add(this.TemperatureUpDown);
            this.Controls.Add(this.PressureLabel);
            this.Controls.Add(this.TempLabel);
            this.Controls.Add(this.CalcRamanShift);
            this.Controls.Add(this.cutWLMpoints);
            this.Controls.Add(this.numberOfShotsUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.ramanShiftUpDown);
            this.Controls.Add(this.valueToAddUpDown);
            this.Controls.Add(this.numberOfColumns);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RegRamanlabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.patchButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonCRDS);
            this.Controls.Add(this.shapeContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Patcher";
            ((System.ComponentModel.ISupportInitialize)(this.numberOfColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueToAddUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ramanShiftUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfShotsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TemperatureUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressureUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCRDS;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label RegRamanlabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numberOfColumns;
        private System.Windows.Forms.OpenFileDialog CRDSopenFileDialog;
        private System.Windows.Forms.OpenFileDialog WLMopenFileDialog;
        private System.Windows.Forms.SaveFileDialog savePatched;
        private System.Windows.Forms.NumericUpDown valueToAddUpDown;
        private System.Windows.Forms.NumericUpDown ramanShiftUpDown;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown numberOfShotsUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button patchButton;
        private System.Windows.Forms.CheckBox cutWLMpoints;
        private System.Windows.Forms.CheckBox CalcRamanShift;
        private System.Windows.Forms.Label TempLabel;
        private System.Windows.Forms.Label PressureLabel;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape3;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.NumericUpDown TemperatureUpDown;
        private System.Windows.Forms.NumericUpDown PressureUpDown;
    }
}

