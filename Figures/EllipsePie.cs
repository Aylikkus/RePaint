using System;
using System.Drawing;

namespace RePaint.Figures
{
    [Serializable]
    class EllipsePie : Rectangle
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
            if (FigureSize.Width != 0 && FigureSize.Height != 0)
                g.DrawPie(FigurePen, Location.X, Location.Y, FigureSize.Width, FigureSize.Height, StartAngle, SweepAngle);
        }

        public override void Erase(Graphics g, Color eraseClr)
        {
            Pen eraser = new Pen(eraseClr);
            eraser.Width = FigureWidth;
            g.DrawPie(eraser, Location.X, Location.Y, FigureSize.Width, FigureSize.Height, StartAngle, SweepAngle);
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
