using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace RePaint.Figures
{
    class TextureCurve : Curve
    {
        Bitmap brush;
        ImageAttributes attr;

        public override void Draw(Graphics g)
        {
            int pWidth = (int)FigurePen.Width;
            
            foreach (var point in points)
            {
                var rect = new System.Drawing.Rectangle(
                new Point(point.X - pWidth / 2, point.Y - pWidth / 2),
                new Size(pWidth, pWidth));

                g.DrawImage(brush, rect, 0, 0, rect.Width, rect.Height, GraphicsUnit.Pixel, attr);
            }
        }

        public TextureCurve(Point[] points, Image brushBmp, ImageAttributes attr, Pen pen)
            : base(points, pen)
        {
            brush = new Bitmap(brushBmp, (int)pen.Width, (int)pen.Width);

            this.attr = attr;
        }
    }
}
