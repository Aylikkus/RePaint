using System;
using System.Drawing;

namespace RePaint.Figures
{
    internal class EllipsePie : Rectangle
    {
        public float StartAngle { get; set; }
        public float SweepAngle { get; set; }

        public override void Update()
        {
            FigureSize = new Size(End.X - Location.X, End.Y - Location.Y);
            squareToLeft = false;

            if (FigureSize.Width < 0)
            {
                switch (selected)
                {
                    case 1:
                        selected = 2;
                        break;
                    case 2:
                        selected = 1;
                        break;
                    case 3:
                        selected = 4;
                        break;
                    case 4:
                        selected = 3;
                        break;
                }

                int ex = End.X;
                int lx = Location.X;
                Location = new Point(ex, Location.Y);
                End = new Point(lx, End.Y);
                squareToLeft = true;

                StartAngle -= 180;
                SweepAngle = -SweepAngle;

                FigureSize = new Size(End.X - Location.X, End.Y - Location.Y);
            }

            if (FigureSize.Height < 0)
            {
                switch (selected)
                {
                    case 1:
                        selected = 3;
                        break;
                    case 2:
                        selected = 4;
                        break;
                    case 3:
                        selected = 1;
                        break;
                    case 4:
                        selected = 2;
                        break;
                }

                int ey = End.Y;
                int ly = Location.Y;
                Location = new Point(Location.X, ey);
                End = new Point(End.X, ly);

                SweepAngle = -SweepAngle;

                FigureSize = new Size(End.X - Location.X, End.Y - Location.Y);
            }
        }

        public override void Draw(Graphics g)
        {
            try
            {
                g.DrawPie(FigurePen, Location.X, Location.Y, FigureSize.Width, FigureSize.Height, StartAngle, SweepAngle);
            }
            catch (ArgumentException) { }
        }

        public override void Erase(Graphics g, Color eraseClr)
        {
            Pen eraser = new Pen(eraseClr);
            eraser.Width = FigurePen.Width;
            g.DrawPie(eraser, Location.X, Location.Y, FigureSize.Width, FigureSize.Height, StartAngle, SweepAngle);
        }

        public override void RedrawAt(Point point, Graphics g)
        {
            switch (selected)
            {
                // Угол не выбран
                case 0:
                    selected = selectCorner(point);
                    break;

                // Левый верхний угол
                case 1:
                    Location = point;
                    Update();
                    Draw(g);
                    break;

                // Правый верхний угол
                case 2:
                    Location = new Point(Location.X, point.Y);
                    End = new Point(point.X, End.Y);
                    Update();
                    Draw(g);
                    break;

                // Нижний левый угол
                case 3:
                    Location = new Point(point.X, Location.Y);
                    End = new Point(End.X, point.Y);
                    Update();
                    Draw(g);
                    break;

                // Нижний правый угол
                case 4:
                    End = point;
                    Update();
                    Draw(g);
                    break;

                // Центр прямоугольника
                case 5:
                    int mx = FigureSize.Width / 2;
                    int my = FigureSize.Height / 2;

                    Location = new Point(point.X + mx, point.Y + my);
                    End = new Point(point.X - mx, point.Y - my);

                    StartAngle += 180;
                    Update();
                    Draw(g);
                    break;

                // Тело прямоугольника
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

                // Левый верхний угол
                case 1:
                    Location = point;
                    Update();
                    DrawSymetrically(g);
                    break;

                // Правый верхний угол
                case 2:
                    Location = new Point(Location.X, point.Y);
                    End = new Point(point.X, End.Y);
                    Update();
                    DrawSymetrically(g);
                    break;

                // Нижний левый угол
                case 3:
                    Location = new Point(point.X, Location.Y);
                    End = new Point(End.X, point.Y);
                    Update();
                    DrawSymetrically(g);
                    break;

                // Нижний правый угол
                case 4:
                    End = point;
                    Update();
                    DrawSymetrically(g);
                    break;

                // Центр прямоугольника
                case 5:
                    int mx = FigureSize.Height / 2;
                    int my = FigureSize.Height / 2;

                    Location = new Point(point.X + mx, point.Y + my);
                    End = new Point(point.X - mx, point.Y - my);

                    StartAngle += 180;
                    Update();
                    Draw(g);
                    break;

                // Тело прямоугольника
                case 255:
                    Update();
                    Draw(g);
                    break;
            }
        }

        public EllipsePie(Point start, Point end, float startAngle, float sweepAngle, Pen pen)
            : base(start, end, pen)
        {
            StartAngle = startAngle;
            SweepAngle = sweepAngle;
            Update();

            selected = 0;
        }
    }
}
