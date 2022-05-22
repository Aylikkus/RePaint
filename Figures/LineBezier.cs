using System;
using System.Drawing;

namespace RePaint.Figures
{
    [Serializable]
    class LineBezier : Figure
    {
        byte selected;

        // Две средние точки
        Point[] points;

        // Массив ссылок на точки
        // Для удобного прохода по ним
        Func<Point>[] pointers;

        private byte selectCorner(Point point)
        {
            for (byte i = 0; i < pointers.Length; i++)
            {
                if (Math.Abs(pointers[i]().X - point.X) < 10 &&
                    Math.Abs(pointers[i]().Y - point.Y) < 10)
                {
                    return (byte)(i + 1);
                }
            }

            return 255;
        }

        public override void Update()
        {
            FigureSize = new Size(Math.Abs(Location.X - points[0].X - points[1].X - End.X),
                            Math.Abs(Location.Y - points[0].Y - points[1].Y - End.Y));
        }

        public override void Draw(Graphics g)
        {
            g.DrawBezier(FigurePen, Location, points[0], points[1], End);
        }

        public override void DrawSymetrically(Graphics g)
        {
            Draw(g);
        }
        public override void Select(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.White), Location.X - 2, Location.Y - 2, 5, 5);
            g.DrawRectangle(new Pen(Color.Black, 2), Location.X - 2, Location.Y - 2, 5, 5);

            foreach (var point in points)
            {
                g.FillRectangle(new SolidBrush(Color.White), point.X - 2, point.Y - 2, 5, 5);
                g.DrawRectangle(new Pen(Color.Black, 2), point.X - 2, point.Y - 2, 5, 5);
            }

            g.FillRectangle(new SolidBrush(Color.White), End.X - 2, End.Y - 2, 5, 5);
            g.DrawRectangle(new Pen(Color.Black, 2), End.X - 2, End.Y - 2, 5, 5);
        }

        public override void ReselectCorner(Point point)
        {
            selected = selectCorner(point);
        }

        public override void Erase(Graphics g, Color eraseClr)
        {
            Pen eraser = new Pen(eraseClr);
            eraser.Width = FigureWidth;
            g.DrawBezier(eraser, Location, points[0], points[1], End);
        }

        public override void RedrawAt(Point point, Graphics g)
        {
            switch (selected)
            {
                // Точка не выбрана
                case 0:
                    selected = selectCorner(point);
                    break;

                // Первая точка
                case 1:
                    Location = point;
                    Update();
                    Draw(g);
                    break;

                // Вторая точка
                case 2:
                    points[0] = point;
                    Update();
                    Draw(g);
                    break;

                // Третья точка
                case 3:
                    points[1] = point;
                    Update();
                    Draw(g);
                    break;

                // Последняя точка
                case 4:
                    End = point;
                    Update();
                    Draw(g);
                    break;

                // Тело линии Безье
                case 255:
                    Update();
                    Draw(g);
                    break;
            }
        }

        public override void RedrawSymetricallyAt(Point point, Graphics g)
        {
            RedrawAt(point, g);
        }

        public override bool Contains(Point point, int offset = 0)
        {
            if (selectCorner(point) != 255)
                return true;

            return false;
        }

        public LineBezier(Point start, Point first, Point second, Point end, Pen pen)
            : base(pen)
        {
            Location = start;
            End = end;
            points = new Point[] { first, second };
            pointers = new Func<Point>[] { () => Location,
                                           () => points[0],
                                           () => points[1],
                                           () => End };

            Update();

            selected = 0;
        }
    }
}
