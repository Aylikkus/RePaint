using System.Drawing;

namespace RePaint.Figures
{
    class Ellipse : Rectangle
    {
        public override void Draw(Graphics g)
        {
            g.DrawEllipse(FigurePen, Location.X, Location.Y, FigureSize.Width, FigureSize.Height);
        }

        public override void Erase(Graphics g, Color eraseClr)
        {
            Pen eraser = new Pen(eraseClr);
            eraser.Width = FigurePen.Width;
            g.DrawEllipse(eraser, Location.X, Location.Y, FigureSize.Width, FigureSize.Height);
        }

        public Ellipse(Point start, Point end, Pen pen)
            : base(start, end, pen)
        {

        }
    }
}

