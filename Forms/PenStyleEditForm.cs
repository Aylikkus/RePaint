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

            PaintAreaArgs.ColorChanged += new EventHandler(paintAreaArgs_ColorChanged);

            opacityTrBar.Value = (int)(PaintAreaArgs.PenColor.A / 2.55);
            opacityLbl.Text = $"Прозрачность {opacityTrBar.Value}";

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
                    points.Add(new Point(i, (previewPanel.Height / 2) - (int)(10 * Math.Cos(i * 2)) ));
                }

                Pen drawPen = PaintAreaArgs.Pen;
                drawPen.Width = 20;

                Figure sinusoid = new BrushCurve(points.ToArray(), PaintAreaArgs.ColoredBrushImage, drawPen);
                Figure line = new Line(new Point(20, 80), new Point(previewPanel.Width - 20, 80), drawPen);

                sinusoid.Draw(g);
                line.Draw(g);
            }

            previewPanel.BackgroundImage = image;
        }

        private void dashStyleDomUpDown_SelectedItemChanged(object sender, EventArgs e)
        {
            PaintAreaArgs.PenDashStyle = (DashStyle)dashStyleDomUpDown.SelectedIndex;
            previewPanelUpdate();
        }

        private void brushPanel_Click(object sender, EventArgs e)
        {
            PaintAreaArgs.PrimaryBrushImage = ((Panel)sender).BackgroundImage;
            previewPanelUpdate();
        }

        private void opacityTrBar_ValueChanged(object sender, EventArgs e)
        {
            Color col = PaintAreaArgs.PenColor;
            int newOpacity = (int)(opacityTrBar.Value * 2.55);
            PaintAreaArgs.PenColor = Color.FromArgb(newOpacity, col.R, col.G, col.B);
            opacityLbl.Text = $"Прозрачность {opacityTrBar.Value}";
            previewPanelUpdate();
        }

        private void paintAreaArgs_ColorChanged(object sender, EventArgs e)
        {
            previewPanelUpdate();
        }

        private void loadBrushBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    PaintAreaArgs.PrimaryBrushImage = new Bitmap(openFileDialog.FileName);
                    previewPanelUpdate();
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Изображение не читается");
                }
            }
        }
    }
}
