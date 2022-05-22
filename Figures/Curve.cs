using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace RePaint.Figures
{
    [Serializable]
    class Curve : Figure
    {
        protected Point[] points;
        protected byte selected = 0;

        protected byte selectCorner(Point point)
        {
            int offset = 20;

            foreach (Point p in points)
            {
                if (Math.Abs(p.X - point.X) < offset + FigureWidth / 2 &&
                    Math.Abs(p.Y - point.Y) < offset + FigureWidth / 2)
                {
                    return 1;
                }
            }

            return 255;
        }

        protected void fillGapsInPoints(Graphics g, Color color, 
            float width)
        {
            Pen temp = new Pen(color, width);
            for (int i = 1; i < points.Length; i++)
            {
                if (Math.Abs(points[i].X - points[i - 1].X) > 1 ||
                    Math.Abs(points[i].Y - points[i - 1].Y) > 1)
                {
                    g.DrawLine(temp, points[i], points[i - 1]);
                }
            }
        }

        public override bool Contains(Point point, int offset = 0)
        {
            foreach (Point p in points)
            {
                if (Math.Abs(p.X - point.X) < offset + FigureWidth / 2 &&
                    Math.Abs(p.Y - point.Y) < offset + FigureWidth / 2)
                {
                    return true;
                }
            }

            return false;
        }

        public override void Draw(Graphics g)
        {
            int pWidth = (int)FigureWidth;
            fillGapsInPoints(g, FigureColor, FigureWidth);
            foreach (var point in points)
            {
                g.FillEllipse(new SolidBrush(FigureColor), new System.Drawing.Rectangle(
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
            int pWidth = (int)FigureWidth;
            fillGapsInPoints(g, eraseClr, FigureWidth);
            foreach (var point in points)
            {
                g.FillEllipse(new SolidBrush(eraseClr), new System.Drawing.Rectangle(
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
            int squareSide = 5 + (int)FigureWidth / 4;
            Size squareSize = new Size(squareSide, squareSide);

            Pen ordinary = new Pen(Color.Black, 2);
            SolidBrush sb = new SolidBrush(Color.White);

            foreach (Point p in points)
            {
                Point edge = p;
                edge.Offset(-squareSide / 2, -squareSide / 2);

                g.FillEllipse(sb, new System.Drawing.Rectangle(edge, squareSize));
                g.DrawEllipse(ordinary, new System.Drawing.Rectangle(edge, squareSize));
            }
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
            : base(pen)
        {
            this.points = points;

            Update();
            selected = 0;
        }
    }
}
