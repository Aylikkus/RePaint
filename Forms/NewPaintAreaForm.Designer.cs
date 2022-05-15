namespace RePaint.Forms
{
    partial class NewPaintAreaForm
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
            this.heightNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.widthNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.clrPanel = new System.Windows.Forms.Panel();
            this.widthLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.clrLabel = new System.Windows.Forms.Label();
            this.checkBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthNumUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // heightNumUpDown
            // 
            this.heightNumUpDown.Location = new System.Drawing.Point(90, 25);
            this.heightNumUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.heightNumUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.heightNumUpDown.Name = "heightNumUpDown";
            this.heightNumUpDown.Size = new System.Drawing.Size(80, 20);
            this.heightNumUpDown.TabIndex = 0;
            this.heightNumUpDown.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.heightNumUpDown.ValueChanged += new System.EventHandler(this.heightNumUpDown_ValueChanged);
            // 
            // widthNumUpDown
            // 
            this.widthNumUpDown.Location = new System.Drawing.Point(0, 25);
            this.widthNumUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.widthNumUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.widthNumUpDown.Name = "widthNumUpDown";
            this.widthNumUpDown.Size = new System.Drawing.Size(80, 20);
            this.widthNumUpDown.TabIndex = 1;
            this.widthNumUpDown.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.widthNumUpDown.ValueChanged += new System.EventHandler(this.widthNumUpDown_ValueChanged);
            // 
            // clrPanel
            // 
            this.clrPanel.BackColor = System.Drawing.Color.White;
            this.clrPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clrPanel.Location = new System.Drawing.Point(175, 25);
            this.clrPanel.Name = "clrPanel";
            this.clrPanel.Size = new System.Drawing.Size(20, 20);
            this.clrPanel.TabIndex = 2;
            this.clrPanel.Click += new System.EventHandler(this.clrPanel_Click);
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(0, 10);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(46, 13);
            this.widthLabel.TabIndex = 3;
            this.widthLabel.Text = "Ширина";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(90, 10);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(45, 13);
            this.heightLabel.TabIndex = 4;
            this.heightLabel.Text = "Высота";
            // 
            // clrLabel
            // 
            this.clrLabel.AutoSize = true;
            this.clrLabel.Location = new System.Drawing.Point(170, 10);
            this.clrLabel.Name = "clrLabel";
            this.clrLabel.Size = new System.Drawing.Size(32, 13);
            this.clrLabel.TabIndex = 5;
            this.clrLabel.Text = "Цвет";
            // 
            // checkBtn
            // 
            this.checkBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.checkBtn.Location = new System.Drawing.Point(0, 53);
            this.checkBtn.Name = "checkBtn";
            this.checkBtn.Size = new System.Drawing.Size(204, 23);
            this.checkBtn.TabIndex = 6;
            this.checkBtn.Text = "Создать";
            this.checkBtn.UseVisualStyleBackColor = true;
            this.checkBtn.Click += new System.EventHandler(this.checkBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "x";
            // 
            // NewPaintAreaForm
            // 
            this.AcceptButton = this.checkBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(204, 76);
            this.Controls.Add(this.checkBtn);
            this.Controls.Add(this.clrLabel);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.widthLabel);
            this.Controls.Add(this.clrPanel);
            this.Controls.Add(this.widthNumUpDown);
            this.Controls.Add(this.heightNumUpDown);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(220, 115);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(220, 115);
            this.Name = "NewPaintAreaForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Создать";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.heightNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthNumUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown heightNumUpDown;
        private System.Windows.Forms.NumericUpDown widthNumUpDown;
        private System.Windows.Forms.Panel clrPanel;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label clrLabel;
        public System.Windows.Forms.Button checkBtn;
        private System.Windows.Forms.Label label1;
    }
}