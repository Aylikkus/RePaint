using System;
using System.Drawing;

namespace RePaint.Figures
{
    [Serializable]
    public class Line : Figure
    {
        Point center;
        protected byte selected;

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

            if (Math.Abs(center.X - point.X) < 10 &&
                Math.Abs(center.Y - point.Y) < 10)
            {
                return 3;
            }

            return 255;
        }

        public override void Update()
        {
            FigureSize = new Size(Math.Abs(End.X - Location.X), Math.Abs(End.Y - Location.Y));

            center = new Point((Location.X + End.X) / 2, (Location.Y + End.Y) / 2);
        }

        public override void Draw(Graphics g)
        {
            g.DrawLine(FigurePen, Location, End);
        }

        public override void Select(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.White), Location.X - 2, Location.Y - 2, 5, 5);
            g.DrawRectangle(new Pen(Color.Black, 2), Location.X - 2, Location.Y - 2, 5, 5);

            g.FillRectangle(new SolidBrush(Color.White), End.X - 2, End.Y - 2, 5, 5);
            g.DrawRectangle(new Pen(Color.Black, 2), End.X - 2, End.Y - 2, 5, 5);

            g.FillEllipse(new SolidBrush(Color.White), center.X - 5, center.Y - 5, 10, 10);
            g.DrawEllipse(new Pen(Color.Black, 2), center.X - 5, center.Y - 5, 10, 10);
        }

        public override void DrawSymetrically(Graphics g)
        {
            if (Math.Abs(Location.Y - End.Y) < 20)
                End = new Point(End.X, Location.Y);
            if (Math.Abs(Location.X - End.X) < 20)
                End = new Point(Location.X, End.Y);
            Update();
            Draw(g);
        }

        public override void ReselectCorner(Point point)
        {
            selected = selectCorner(point);
        }

        public override void Erase(Graphics g, Color eraseClr)
        {
            Pen eraser = new Pen(eraseClr);
            eraser.Width = FigureWidth;
            g.DrawLine(eraser, Location, End);
        }

        public override void RedrawAt(Point point, Graphics g)
        {
            switch (selected)
            {
                // Угол не выбран
                case 0:
                    selected = selectCorner(point);
                    break;

                // Начало линии
                case 1:
                    Location = point;

                    Update();
                    Draw(g);
                    break;

                // Конец линии
                case 2:
                    End = point;

                    Update();
                    Draw(g);
                    break;

                // Центр линии
                case 3:

                    Location = new Point(point.X - center.X + Location.X, point.Y - center.Y + Location.Y);
                    End = new Point(point.X - center.X + End.X, point.Y - center.Y + End.Y);

                    Update();
                    Draw(g);
                    break;

                // Тело линии
                case 255:
                    Update();
                    Draw(g);
                    break;
            }
        }

        public override void RedrawSymetricallyAt(Point point, Graphics g)
        {
            switch (selected)
            {
                // Угол не выбран
                case 0:
                    selected = selectCorner(point);
                    break;

                // Начало линии
                case 1:
                    Location = point;

                    Update();
                    DrawSymetrically(g);
                    break;

                // Конец линии
                case 2:
                    End = point;

                    Update();
                    DrawSymetrically(g);
                    break;
                // Центр линии
                case 3:

                    Location = new Point(point.X - center.X + Location.X, point.Y - center.Y + Location.Y);
                    End = new Point(point.X - center.X + End.X, point.Y - center.Y + End.Y);

                    Update();
                    DrawSymetrically(g);
                    break;

                // Тело линии
                case 255:
                    Update();
                    DrawSymetrically(g);
                    break;
            }
        }

        public override bool Contains(Point point, int offset = 0)
        {
            // Проверяем на выпадение из прямоугольника
            if ((point.X < Location.X - offset && point.X < End.X - offset) ||
                (point.X > Location.X + offset && point.X > End.X + offset) ||
                (point.Y < Location.Y - offset && point.Y < End.Y - offset) ||
                (point.Y > Location.Y + offset && point.Y > End.Y + offset))
                return false;

            // Рассчитываем дистанцию
            int dy = End.Y - Location.Y;
            int dx = End.X - Location.X;
            int numerator = dy * point.X - dx * point.Y + Location.Y * End.X - Location.X * End.Y;
            int denominator = dy * dy + dx * dx;
            float dist = (float)(Math.Abs(numerator) / Math.Sqrt(denominator));

            return dist < (offset + FigureWidth);
        }

        public Line(Point start, Point end, Pen pen)
            : base(pen)
        {
            Location = start;
            End = end;

            Update();

            selected = 0;
        }
    }
}
