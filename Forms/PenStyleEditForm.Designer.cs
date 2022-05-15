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
            this.previewPanel = new System.Windows.Forms.Panel();
            this.dashStyleDomUpDown = new System.Windows.Forms.DomainUpDown();
            this.rectangleBrPnl = new System.Windows.Forms.Panel();
            this.solidBrPnl = new System.Windows.Forms.Panel();
            this.grassBrPnl = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // previewPanel
            // 
            this.previewPanel.BackColor = System.Drawing.Color.White;
            this.previewPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewPanel.Location = new System.Drawing.Point(12, 168);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(300, 100);
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
            this.dashStyleDomUpDown.Size = new System.Drawing.Size(300, 20);
            this.dashStyleDomUpDown.TabIndex = 0;
            this.dashStyleDomUpDown.Text = "Пунктир";
            this.dashStyleDomUpDown.SelectedItemChanged += new System.EventHandler(this.dashStyleDomUpDown_SelectedItemChanged);
            // 
            // rectangleBrPnl
            // 
            this.rectangleBrPnl.BackgroundImage = global::RePaint.Properties.Resources.rectangle;
            this.rectangleBrPnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.rectangleBrPnl.Location = new System.Drawing.Point(48, 12);
            this.rectangleBrPnl.Name = "rectangleBrPnl";
            this.rectangleBrPnl.Size = new System.Drawing.Size(30, 30);
            this.rectangleBrPnl.TabIndex = 0;
            // 
            // solidBrPnl
            // 
            this.solidBrPnl.BackgroundImage = global::RePaint.Properties.Resources.solidBrush;
            this.solidBrPnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.solidBrPnl.Location = new System.Drawing.Point(12, 12);
            this.solidBrPnl.Name = "solidBrPnl";
            this.solidBrPnl.Size = new System.Drawing.Size(30, 30);
            this.solidBrPnl.TabIndex = 1;
            // 
            // grassBrPnl
            // 
            this.grassBrPnl.BackgroundImage = global::RePaint.Properties.Resources.grass;
            this.grassBrPnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.grassBrPnl.Location = new System.Drawing.Point(84, 12);
            this.grassBrPnl.Name = "grassBrPnl";
            this.grassBrPnl.Size = new System.Drawing.Size(30, 30);
            this.grassBrPnl.TabIndex = 1;
            // 
            // PenStyleEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 303);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel previewPanel;
        private System.Windows.Forms.DomainUpDown dashStyleDomUpDown;
        private System.Windows.Forms.Panel solidBrPnl;
        private System.Windows.Forms.Panel rectangleBrPnl;
        private System.Windows.Forms.Panel grassBrPnl;
    }
}