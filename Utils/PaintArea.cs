using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Collections.Generic;

using RePaint.Figures;

namespace RePaint.Utils
{
    public class PaintArea
    {
        public PictureBox PictureBox { get; }

        public static State State { get; set; }

        public static ImageAttributes ImageAttributes { get; set; }
        public static Image BrushImage { get; set; }

        public static Pen Pen { get; set; }
        public static Pen Eraser { get; private set; } = Pens.Transparent;

        public static Color FillColor { get; set; }

        public static float SprayDistribution { get; set; }
        public static float PieStartAngle { get; set; }
        public static float PieSweepAngle { get; set; }

        public static bool IsPainting { get; private set; }

        public List<Figure> Figures { get; private set; }
        public List<Point> Points { get; private set; }


        static ColorMap[] colorMap;

        Point pStart, pEnd;
        int selIndex;

        public void Clear()
        {
            Figures.Clear();
            PictureBox.Image = null;
        }

        public void AssignTo(Panel paintPanel)
        {
            paintPanel.Controls.Clear();
            paintPanel.Controls.Add(PictureBox);
        }

        public void SelectAll()
        {
            //
        }

        public static void UpdateImageAttributes()
        {
            colorMap = new ColorMap[256];
            for (int i = 0; i < 256; i++)
            {
                colorMap[i] = new ColorMap();
                colorMap[i].OldColor = Color.FromArgb(i, Color.Black);
                colorMap[i].NewColor = Color.FromArgb(i, Pen.Color);
            }

            ImageAttributes = new ImageAttributes();
            ImageAttributes.SetRemapTable(colorMap);
        }

        #region Конструкторы
        public PaintArea(Pen pen)
        {
            PictureBox = new PictureBox();
            PictureBox.Size = new Size(800, 600);
            PictureBox.Image = new Bitmap(800, 600);
            PictureBox.BackgroundImage = Properties.Resources.transparency;

            PictureBox.Location = new Point(0, 0);

            PictureBox.Paint += new PaintEventHandler(pictureBox_Paint);
            PictureBox.MouseMove += new MouseEventHandler(pictureBox_MouseMove);
            PictureBox.MouseDown += new MouseEventHandler(pictureBox_MouseDown);
            PictureBox.MouseUp += new MouseEventHandler(pictureBox_MouseUp);
            PictureBox.MouseLeave += new EventHandler(pictureBox_MouseLeave);

            Pen = pen;
            BrushImage = Properties.Resources.solidBrush;
            Eraser = new Pen(Color.Transparent, Pen.Width);

            FillColor = Color.White;
            Figures = new List<Figure>();
            Points = new List<Point>(4);
            IsPainting = false;
            selIndex = -1;

            UpdateImageAttributes();
        }

        public PaintArea(int width, int height, Pen pen)
            : this(pen)
        {
            PictureBox.Size = new Size(width, height);
            PictureBox.Image = new Bitmap(width, height);
        }

        public PaintArea(Image image, Pen pen)
            : this(pen)
        {
            PictureBox.Size = image.Size;
            PictureBox.Image = image;
        }

        public PaintArea(int width, int height, Pen pen, Color bgClr)
            : this(width, height, pen)
        {
            PictureBox.BackColor = bgClr;
            FillColor = bgClr;

            using (var g = Graphics.FromImage(PictureBox.Image))
            {
                g.FillRectangle(new SolidBrush(bgClr), 0, 0, PictureBox.Width, PictureBox.Height);
            }
        }
        #endregion

        private void handler(Graphics g, bool saving)
        {
            Figure figure = null;

            switch (State)
            {
                case State.Cursor:
                    if (selIndex != -1 && saving)
                    {
                        if (Control.ModifierKeys == Keys.Shift)
                            Figures[selIndex].RedrawSymetricallyAt(pEnd, g);
                        else
                            Figures[selIndex].RedrawAt(pEnd, g);
                    }
                    else if (selIndex != -1)
                    {

                        Figure tempFig = Figures[selIndex].Copy();
                        if (Control.ModifierKeys == Keys.Shift)
                            tempFig.RedrawSymetricallyAt(pEnd, g);
                        else
                            tempFig.RedrawAt(pEnd, g);
                        tempFig.Select(g);
                    }
                    break;
                case State.Brush:
                    figure = new TextureCurve(Points.ToArray(), BrushImage, ImageAttributes, Pen);
                    break;
                case State.Curve:
                    figure = new Curve(Points.ToArray(), Pen);
                    break;
                case State.Eraser:
                    figure = new Curve(Points.ToArray(), Eraser);
                    break;
                case State.Line:
                    figure = new Line(pStart, pEnd, Pen);
                    break;
                case State.Rectangle:
                    figure = new Figures.Rectangle(pStart, pEnd, Pen);
                    break;
                case State.Ellipse:
                    figure = new Ellipse(pStart, pEnd, Pen);
                    break;
                case State.EllipsePie:
                    figure = new EllipsePie(pStart, pEnd, PieStartAngle, PieSweepAngle, Pen);
                    break;
                case State.LineBezier:
                    Point middle = new Point((pEnd.X - pStart.X) / 2 + pStart.X,
                                             (pEnd.Y - pStart.X) / 2 + pStart.Y);
                    figure = new LineBezier(pStart, middle, middle, pEnd, Pen);
                    break;
            }

            if (figure != null)
            {
                if (State == State.Eraser)
                {
                    g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                    figure.Draw(g);
                    return;
                }

                if (Control.ModifierKeys == Keys.Shift)
                    figure.DrawSymetrically(g);
                else
                    figure.Draw(g);

                if (saving && State != State.Brush)
                    Figures.Insert(0, figure);
            }
        }

        #region События
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            handler(e.Graphics, false);
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            pEnd = e.Location;

            if (pEnd.X < 0)
                pEnd = new Point(0, pEnd.Y);
            if (pEnd.Y < 0)
                pEnd = new Point(pEnd.X, 0);
            if (pEnd.X > PictureBox.Width)
                pEnd = new Point(PictureBox.Width, pEnd.Y);
            if (pEnd.Y > PictureBox.Height)
                pEnd = new Point(pEnd.X, PictureBox.Height);

            if (IsPainting)
            {
                if (State == State.SprayCurve)
                {
                    using (var g = Graphics.FromImage(PictureBox.Image))
                    {
                        Figure fig = new SprayCurve(Points.ToArray(), SprayDistribution, Pen);
                        fig.Draw(g);
                    }
                }

                Points.Add(pEnd);
                PictureBox.Refresh();
            }
            else if (!IsPainting && State == State.Brush || State == State.Eraser)
            {
                Points = new List<Point>() { pEnd };
                PictureBox.Refresh();
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            pStart = e.Location;
            IsPainting = true;

            Points.Insert(0, pStart);

            if (State == State.Cursor)
            {
                for (int i = 0; i < Figures.Count; i++)
                {
                    if (Figures[i].Contains(pStart, 5))
                    {
                        selIndex = i;
                        Figures[selIndex].ReselectCorner(e.Location);
                        using (var g = Graphics.FromImage(PictureBox.Image))
                        {
                            Figures[selIndex].Erase(g, FillColor);
                        }
                        break;
                    }
                    else
                    {
                        selIndex = -1;
                    }
                }
            }

            if (State == State.Delete)
            {
                for (int i = 0; i < Figures.Count; i++)
                {
                    if (Figures[i].Contains(pStart, 5))
                    {
                        using (var g = Graphics.FromImage(PictureBox.Image))
                        {
                            Figures[i].Erase(g, FillColor);
                            Figures.RemoveAt(i);
                        }
                        break;
                    }
                }
            }

            Points.Add(pEnd);
            PictureBox.Refresh();
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {

            IsPainting = false;

            using (var g = Graphics.FromImage(PictureBox.Image))
            {
                handler(g, true);
            }

            Points.Clear();
            selIndex = -1;
        }

        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (!IsPainting && State == State.Brush || State == State.Eraser)
            {
                Points = new List<Point>();
                PictureBox.Refresh();
            }
        }
        #endregion
    }
}
