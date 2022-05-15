using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace RePaint.Figures
{
    class Curve : Figure
    {
        protected Point[] points;
        protected byte selected = 0;

        protected byte selectCorner(Point point)
        {
            if (Math.Abs(Location.X - point.X) < 10 &&
                Math.Abs(Location.Y - point.Y) < 10)
            {
                return 1;
            }

            if (Math.Abs(End.X - point.X) < 10 &&
                Math.Abs(End.Y - point.Y) < 10)
            {
                return 2;
            }

            return 255;
        }

        protected void fillGapsInPoints(Graphics g, Pen pen)
        {
            Pen temp = (Pen)pen.Clone();
            temp.DashStyle = DashStyle.Solid;
            for (int i = 0; i < points.Length; i++)
            {
                if (i == 0)
                    continue;
                if (Math.Abs(points[i].X - points[i - 1].X) > 1 ||
                    Math.Abs(points[i].Y - points[i - 1].Y) > 1)
                {
                    g.DrawLine(temp, points[i], points[i - 1]);
                }
            }
        }

        public override bool Contains(Point point, int offset = 0)
        {
            if (Math.Abs(Location.X - point.X) < 10 &&
                Math.Abs(Location.Y - point.Y) < 10)
            {
                return true;
            }

            if (Math.Abs(End.X - point.X) < 10 &&
                Math.Abs(End.Y - point.Y) < 10)
            {
                return true;
            }

            return false;
        }

        public override void Draw(Graphics g)
        {
            int pWidth = (int)FigurePen.Width;
            fillGapsInPoints(g, FigurePen);
            foreach (var point in points)
            {
                g.FillEllipse(FigurePen.Brush, new System.Drawing.Rectangle(
                new Point(point.X - pWidth / 2, point.Y - pWidth / 2),
                new Size(pWidth, pWidth)));
            }
        }

        public override void DrawSymetrically(Graphics g)
        {
            Draw(g);
        }

        public override void Erase(Graphics g, Color eraseClr)
        {
            Pen eraser = new Pen(eraseClr);
            eraser.Width = FigurePen.Width;

            int pWidth = (int)FigurePen.Width;
            fillGapsInPoints(g, eraser);
            foreach (var point in points)
            {
                g.FillEllipse(eraser.Brush, new System.Drawing.Rectangle(
                new Point(point.X - pWidth / 2, point.Y - pWidth / 2),
                new Size(pWidth, pWidth)));
            }
        }

        public override void RedrawAt(Point point, Graphics g)
        {
            Update();
            Draw(g);
        }

        public override void RedrawSymetricallyAt(Point point, Graphics g)
        {
            RedrawAt(point, g);
        }

        public override void ReselectCorner(Point point)
        {
            selected = 0;
        }

        public override void Select(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.White), Location.X - 2, Location.Y - 2, 5, 5);
            g.DrawRectangle(new Pen(Color.Black, 2), Location.X - 2, Location.Y - 2, 5, 5);

            g.FillRectangle(new SolidBrush(Color.White), End.X - 2, End.Y - 2, 5, 5);
            g.DrawRectangle(new Pen(Color.Black, 2), End.X - 2, End.Y - 2, 5, 5);
        }

        public override void Update()
        {
            if (points.Length == 0)
                return;

            Location = points[0];
            End = points[points.Length - 1];

            // Прямоугольник, образованный от начальной и конечной координаты
            FigureSize = new Size(Math.Abs(End.X - Location.X), Math.Abs(End.Y - Location.Y));
        }

        public Curve(Point[] points, Pen pen)
        {
            this.points = points;

            FigurePen = pen;

            Update();
            selected = 0;
        }
    }
}
