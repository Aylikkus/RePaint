using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

using RePaint.Figures;
using RePaint.Utils;

namespace RePaint.Forms
{
    public partial class PenStyleEditForm : Form
    {
        public PenStyleEditForm()
        {
            InitializeComponent();

            solidBrPnl.Click += new EventHandler(brushPanel_Click);
            rectangleBrPnl.Click += new EventHandler(brushPanel_Click);
            grassBrPnl.Click += new EventHandler(brushPanel_Click);

            previewPanelUpdate();
        }

        private void previewPanelUpdate()
        {
            Image image = new Bitmap(previewPanel.Width, previewPanel.Height);
            using (Graphics g = Graphics.FromImage(image))
            {
                List<Point> points = new List<Point>();
                for (int i = 20; i < previewPanel.Width - 20; i += 3)
                {
                    points.Add(new Point(i, (previewPanel.Height / 2) - (int)(20 * Math.Cos(i * 2)) ));
                }

                Pen temp = (Pen)PaintArea.Pen.Clone();
                temp.Width = 4;

                Figure sinusoid = new TextureCurve(points.ToArray(), PaintArea.BrushImage, PaintArea.ImageAttributes, temp);
                Figure line = new Line(new Point(20, 80), new Point(previewPanel.Width - 20, 80), temp);

                sinusoid.Draw(g);
                line.Draw(g);
            }

            previewPanel.BackgroundImage = image;
        }

        private void dashStyleDomUpDown_SelectedItemChanged(object sender, EventArgs e)
        {
            PaintArea.Pen.DashStyle = (DashStyle)dashStyleDomUpDown.SelectedIndex;
            PaintArea.UpdateImageAttributes();
            previewPanelUpdate();
        }

        private void brushPanel_Click(object sender, EventArgs e)
        {
            PaintArea.BrushImage = ((Panel)sender).BackgroundImage;
            previewPanelUpdate();
        }
    }
}
