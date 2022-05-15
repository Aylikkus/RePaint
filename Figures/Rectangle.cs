using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace RePaint.Figures
{
    class Rectangle : Figure
    {
        protected byte selected;
        protected bool squareToLeft;

        protected byte selectCorner(Point point)
        {
            int offset = 15;

            if (Math.Abs(Location.X - point.X) < offset &&
                Math.Abs(Location.Y - point.Y) < offset)
            {
                return 1;
            }

            if (Math.Abs(Location.X + FigureSize.Width - point.X) < offset &&
                Math.Abs(Location.Y - point.Y) < offset)
            {
                return 2;
            }

            if (Math.Abs(Location.X - point.X) < offset &&
                Math.Abs(Location.Y + FigureSize.Height - point.Y) < offset)
            {
                return 3;
            }

            if (Math.Abs(End.X - point.X) < offset &&
                Math.Abs(End.Y - point.Y) < offset)
            {
                return 4;
            }

            if (Math.Abs(Location.X + FigureSize.Width / 2 - point.X) < offset &&
                Math.Abs(Location.Y + FigureSize.Height / 2 - point.Y) < offset)
                return 5;

            return 255;
        }

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

                FigureSize = new Size(End.X - Location.X, End.Y - Location.Y);
            }
        }


        public override void Draw(Graphics g)
        {
            g.DrawRectangle(FigurePen, Location.X, Location.Y, FigureSize.Width, FigureSize.Height);
        }

        public override void Select(Graphics g)
        {
            int squareHeight = (int)FigurePen.Width / 2;
            Size squareSize = new Size(squareHeight, squareHeight);

            Point upLeft = Location;
            Point upRight = new Point(End.X, Location.Y);
            Point downLeft = new Point(Location.X, End.Y);
            Point downRight = End;

            upLeft.Offset(-squareHeight / 2, -squareHeight / 2);
            upRight.Offset(-squareHeight / 2, -squareHeight / 2);
            downLeft.Offset(-squareHeight / 2, -squareHeight / 2);
            downRight.Offset(-squareHeight / 2, -squareHeight / 2);


            Point center = new Point((End.X + Location.X) / 2, (Location.Y + End.Y) / 2);

            Pen ordinary = new Pen(Color.Black, squareHeight);

            // Штриховое выделение прямоугольника
            Pen dotted = new Pen(Color.Gray, 1);
            dotted.DashStyle = DashStyle.Dash;
            g.DrawRectangle(dotted, Location.X, Location.Y, FigureSize.Width, FigureSize.Height);

            // Выделение 4-ёх углов прямоугольника
            g.FillRectangle(new SolidBrush(Color.White), new System.Drawing.Rectangle(upLeft, squareSize));
            g.FillRectangle(new SolidBrush(Color.White), new System.Drawing.Rectangle(downLeft, squareSize));
            g.FillRectangle(new SolidBrush(Color.White), new System.Drawing.Rectangle(downRight, squareSize));
            g.FillRectangle(new SolidBrush(Color.White), new System.Drawing.Rectangle(upRight, squareSize));


            g.DrawRectangle(ordinary, new System.Drawing.Rectangle(upLeft, squareSize));
            g.DrawRectangle(ordinary, new System.Drawing.Rectangle(upRight, squareSize));
            g.DrawRectangle(ordinary, new System.Drawing.Rectangle(downLeft, squareSize));
            g.DrawRectangle(ordinary, new System.Drawing.Rectangle(downRight, squareSize));

            g.FillEllipse(new SolidBrush(Color.White), new System.Drawing.Rectangle(center, squareSize));
            g.DrawEllipse(ordinary, new System.Drawing.Rectangle(center, squareSize));
        }
        public override void DrawSymetrically(Graphics g)
        {
            switch (selected)
            {
                case 0:
                    if (!squareToLeft)
                        End = new Point(Location.X + FigureSize.Height, End.Y);
                    else
                        Location = new Point(End.X - FigureSize.Height, Location.Y);
                    break;
                case 1:
                case 3:
                    Location = new Point(End.X - FigureSize.Height, Location.Y);
                    break;
                case 2:
                case 4:
                    End = new Point(Location.X + FigureSize.Height, End.Y);
                    break;
            }

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
            eraser.Width = FigurePen.Width;
            g.DrawRectangle(eraser, Location.X, Location.Y, FigureSize.Width, FigureSize.Height);
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

        public override bool Contains(Point point, int offset = 0)
        {
            offset += (int)FigurePen.Width;

            if ((point.X < Location.X - offset && point.X < End.X - offset) ||
                (point.X > Location.X + offset && point.X > End.X + offset) ||
                (point.Y < Location.Y - offset && point.Y < End.Y - offset) ||
                (point.Y > Location.Y + offset && point.Y > End.Y + offset))
                return false;

            return true;
        }

        public Rectangle(Point start, Point end, Pen pen)
        {
            Location = start;
            End = end;
            FigurePen = pen;

            Update();

            selected = 0;
        }
    }
}
