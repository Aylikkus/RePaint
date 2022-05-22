namespace RePaint.Forms
{
    partial class PenStyleEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PenStyleEditForm));
            this.previewPanel = new System.Windows.Forms.Panel();
            this.dashStyleDomUpDown = new System.Windows.Forms.DomainUpDown();
            this.opacityTrBar = new System.Windows.Forms.TrackBar();
            this.opacityLbl = new System.Windows.Forms.Label();
            this.p_br5Pnl = new System.Windows.Forms.Panel();
            this.p_br4Pnl = new System.Windows.Forms.Panel();
            this.p_br3Pnl = new System.Windows.Forms.Panel();
            this.p_br2Pnl = new System.Windows.Forms.Panel();
            this.p_br1Pnl = new System.Windows.Forms.Panel();
            this.cir_br1Pnl = new System.Windows.Forms.Panel();
            this.grassBrPnl = new System.Windows.Forms.Panel();
            this.rectangleBrPnl = new System.Windows.Forms.Panel();
            this.solidBrPnl = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.opacityTrBar)).BeginInit();
            this.SuspendLayout();
            // 
            // previewPanel
            // 
            this.previewPanel.BackColor = System.Drawing.Color.White;
            this.previewPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewPanel.Location = new System.Drawing.Point(12, 168);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(318, 100);
            this.previewPanel.TabIndex = 0;
            // 
            // dashStyleDomUpDown
            // 
            this.dashStyleDomUpDown.Items.Add("Обычный");
            this.dashStyleDomUpDown.Items.Add("Штриховой");
            this.dashStyleDomUpDown.Items.Add("Пунктирный");
            this.dashStyleDomUpDown.Items.Add("Штрихпунктирный");
            this.dashStyleDomUpDown.Items.Add("Два пунктира со штрихом");
            this.dashStyleDomUpDown.Location = new System.Drawing.Point(12, 274);
            this.dashStyleDomUpDown.Name = "dashStyleDomUpDown";
            this.dashStyleDomUpDown.Size = new System.Drawing.Size(318, 20);
            this.dashStyleDomUpDown.TabIndex = 0;
            this.dashStyleDomUpDown.Text = "Пунктир";
            this.dashStyleDomUpDown.SelectedItemChanged += new System.EventHandler(this.dashStyleDomUpDown_SelectedItemChanged);
            // 
            // opacityTrBar
            // 
            this.opacityTrBar.Location = new System.Drawing.Point(223, 117);
            this.opacityTrBar.Maximum = 100;
            this.opacityTrBar.Name = "opacityTrBar";
            this.opacityTrBar.Size = new System.Drawing.Size(107, 45);
            this.opacityTrBar.TabIndex = 2;
            this.opacityTrBar.TickFrequency = 10;
            this.opacityTrBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.opacityTrBar.Value = 100;
            this.opacityTrBar.ValueChanged += new System.EventHandler(this.opacityTrBar_ValueChanged);
            // 
            // opacityLbl
            // 
            this.opacityLbl.AutoSize = true;
            this.opacityLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opacityLbl.Location = new System.Drawing.Point(226, 101);
            this.opacityLbl.Name = "opacityLbl";
            this.opacityLbl.Size = new System.Drawing.Size(100, 13);
            this.opacityLbl.TabIndex = 3;
            this.opacityLbl.Text = "Прозрачность 100";
            // 
            // p_br5Pnl
            // 
            this.p_br5Pnl.BackgroundImage = global::RePaint.Properties.Resources.paint_brush5;
            this.p_br5Pnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.p_br5Pnl.Location = new System.Drawing.Point(300, 12);
            this.p_br5Pnl.Name = "p_br5Pnl";
            this.p_br5Pnl.Size = new System.Drawing.Size(30, 30);
            this.p_br5Pnl.TabIndex = 7;
            this.p_br5Pnl.Click += new System.EventHandler(this.brushPanel_Click);
            // 
            // p_br4Pnl
            // 
            this.p_br4Pnl.BackgroundImage = global::RePaint.Properties.Resources.paint_brush4;
            this.p_br4Pnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.p_br4Pnl.Location = new System.Drawing.Point(264, 12);
            this.p_br4Pnl.Name = "p_br4Pnl";
            this.p_br4Pnl.Size = new System.Drawing.Size(30, 30);
            this.p_br4Pnl.TabIndex = 6;
            this.p_br4Pnl.Click += new System.EventHandler(this.brushPanel_Click);
            // 
            // p_br3Pnl
            // 
            this.p_br3Pnl.BackgroundImage = global::RePaint.Properties.Resources.paint_brush3;
            this.p_br3Pnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.p_br3Pnl.Location = new System.Drawing.Point(228, 12);
            this.p_br3Pnl.Name = "p_br3Pnl";
            this.p_br3Pnl.Size = new System.Drawing.Size(30, 30);
            this.p_br3Pnl.TabIndex = 5;
            this.p_br3Pnl.Click += new System.EventHandler(this.brushPanel_Click);
            // 
            // p_br2Pnl
            // 
            this.p_br2Pnl.BackgroundImage = global::RePaint.Properties.Resources.paint_brush2;
            this.p_br2Pnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.p_br2Pnl.Location = new System.Drawing.Point(192, 12);
            this.p_br2Pnl.Name = "p_br2Pnl";
            this.p_br2Pnl.Size = new System.Drawing.Size(30, 30);
            this.p_br2Pnl.TabIndex = 4;
            this.p_br2Pnl.Click += new System.EventHandler(this.brushPanel_Click);
            // 
            // p_br1Pnl
            // 
            this.p_br1Pnl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("p_br1Pnl.BackgroundImage")));
            this.p_br1Pnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.p_br1Pnl.Location = new System.Drawing.Point(156, 12);
            this.p_br1Pnl.Name = "p_br1Pnl";
            this.p_br1Pnl.Size = new System.Drawing.Size(30, 30);
            this.p_br1Pnl.TabIndex = 3;
            this.p_br1Pnl.Click += new System.EventHandler(this.brushPanel_Click);
            // 
            // cir_br1Pnl
            // 
            this.cir_br1Pnl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cir_br1Pnl.BackgroundImage")));
            this.cir_br1Pnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cir_br1Pnl.Location = new System.Drawing.Point(120, 12);
            this.cir_br1Pnl.Name = "cir_br1Pnl";
            this.cir_br1Pnl.Size = new System.Drawing.Size(30, 30);
            this.cir_br1Pnl.TabIndex = 2;
            this.cir_br1Pnl.Click += new System.EventHandler(this.brushPanel_Click);
            // 
            // grassBrPnl
            // 
            this.grassBrPnl.BackgroundImage = global::RePaint.Properties.Resources.Grass;
            this.grassBrPnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.grassBrPnl.Location = new System.Drawing.Point(84, 12);
            this.grassBrPnl.Name = "grassBrPnl";
            this.grassBrPnl.Size = new System.Drawing.Size(30, 30);
            this.grassBrPnl.TabIndex = 1;
            // 
            // rectangleBrPnl
            // 
            this.rectangleBrPnl.BackgroundImage = global::RePaint.Properties.Resources.Rectangle;
            this.rectangleBrPnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.rectangleBrPnl.Location = new System.Drawing.Point(48, 12);
            this.rectangleBrPnl.Name = "rectangleBrPnl";
            this.rectangleBrPnl.Size = new System.Drawing.Size(30, 30);
            this.rectangleBrPnl.TabIndex = 0;
            // 
            // solidBrPnl
            // 
            this.solidBrPnl.BackgroundImage = global::RePaint.Properties.Resources.SolidBrush;
            this.solidBrPnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.solidBrPnl.Location = new System.Drawing.Point(12, 12);
            this.solidBrPnl.Name = "solidBrPnl";
            this.solidBrPnl.Size = new System.Drawing.Size(30, 30);
            this.solidBrPnl.TabIndex = 1;
            // 
            // PenStyleEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 303);
            this.Controls.Add(this.p_br5Pnl);
            this.Controls.Add(this.p_br4Pnl);
            this.Controls.Add(this.p_br3Pnl);
            this.Controls.Add(this.p_br2Pnl);
            this.Controls.Add(this.p_br1Pnl);
            this.Controls.Add(this.cir_br1Pnl);
            this.Controls.Add(this.opacityLbl);
            this.Controls.Add(this.opacityTrBar);
            this.Controls.Add(this.grassBrPnl);
            this.Controls.Add(this.rectangleBrPnl);
            this.Controls.Add(this.solidBrPnl);
            this.Controls.Add(this.dashStyleDomUpDown);
            this.Controls.Add(this.previewPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PenStyleEditForm";
            this.ShowIcon = false;
            this.Text = "Стиль пера";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.opacityTrBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel previewPanel;
        private System.Windows.Forms.DomainUpDown dashStyleDomUpDown;
        private System.Windows.Forms.Panel solidBrPnl;
        private System.Windows.Forms.Panel rectangleBrPnl;
        private System.Windows.Forms.Panel grassBrPnl;
        private System.Windows.Forms.TrackBar opacityTrBar;
        private System.Windows.Forms.Label opacityLbl;
        private System.Windows.Forms.Panel cir_br1Pnl;
        private System.Windows.Forms.Panel p_br1Pnl;
        private System.Windows.Forms.Panel p_br2Pnl;
        private System.Windows.Forms.Panel p_br3Pnl;
        private System.Windows.Forms.Panel p_br4Pnl;
        private System.Windows.Forms.Panel p_br5Pnl;
    }
}