using System.Drawing;
using System.Drawing.Drawing2D;

namespace RePaint.Figures
{
    class SelectAreaRect : Rectangle
    {
        Image baseRectImg;
        Image image;

        bool flipHoriz;
        bool flipVert;

        public override void Draw(Graphics g)
        {
            if (image is null)
            {
                Pen outer = new Pen(Color.White, 3);

                Pen dottedInner = new Pen(Color.Black, 2);
                dottedInner.DashStyle = DashStyle.Dash;

                g.DrawRectangle(outer, Location.X, Location.Y, 
                    FigureSize.Width, FigureSize.Height);
                g.DrawRectangle(dottedInner, Location.X, Location.Y,
                    FigureSize.Width, FigureSize.Height);
            }
            else
            {
                g.DrawImage(image, Location);
            }
        }

        public override void Erase(Graphics g, Color eraseClr)
        {
            g.FillRectangle(new SolidBrush(eraseClr), Location.X, Location.Y, 
                FigureSize.Width, FigureSize.Height);
        }

        public override void Update()
        {
            FigureSize = new Size(End.X - Location.X, End.Y - Location.Y);
            squareToLeft = false;

            flipHoriz = false;
            flipVert = false;

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

                flipHoriz = true;
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

                flipVert = true;
            }

            if (baseRectImg != null && FigureSize.Width != 0 && FigureSize.Height != 0)
            {
                image = new Bitmap(baseRectImg, FigureSize);

                if (flipHoriz)
                {
                    image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }
                   
                if (flipVert)
                {
                    image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                }
            }
        }

        public override void ReselectCorner(Point point)
        {
            base.ReselectCorner(point);

            if (flipHoriz)
            {
                baseRectImg.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            if (flipVert)
            {
                baseRectImg.RotateFlip(RotateFlipType.RotateNoneFlipY);
            }
        }

        public SelectAreaRect(Point start, Point end, Image baseImage)
            : base(start, end, Pens.Black)
        {
            Bitmap bm = null;
            if (baseImage != null)
            {
                bm = new Bitmap(FigureSize.Width, FigureSize.Height);
                var rect = new System.Drawing.Rectangle(
                    Location.X, Location.Y, FigureSize.Width, FigureSize.Height);
                using (var g = Graphics.FromImage(bm))
                {
                    g.DrawImage(baseImage, new System.Drawing.Rectangle(
                        0, 0, FigureSize.Width, FigureSize.Height),
                        rect, GraphicsUnit.Pixel);
                }
            }

            baseRectImg = bm;
            image = bm;
        }
    }
}
