using System;
using System.Drawing;

namespace RePaint.Figures
{
    [Serializable]
    class BrushCurve : Curve
    {
        Bitmap brush;

        public override void Draw(Graphics g)
        {
            int pWidth = (int)FigureWidth;
            foreach (var point in points)
            {
                var rect = new System.Drawing.Rectangle(
                new Point(point.X - pWidth / 2, point.Y - pWidth / 2),
                new Size(pWidth, pWidth));

                g.DrawImage(brush, rect);
            }
        }

        public BrushCurve(Point[] points, Image brushBmp,  Pen pen)
            : base(points, pen)
        {
            brush = new Bitmap(brushBmp, (int)pen.Width, (int)pen.Width);
        }
    }
}
