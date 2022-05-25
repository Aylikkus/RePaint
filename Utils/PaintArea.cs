using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

using RePaint.Figures;

namespace RePaint.Utils
{
    [Serializable]
    public class PaintArea
    {
        [NonSerialized]
        PictureBox _pictureBox;

        List<Point> _points;

        List<Figure> _figures;

        Point _pStart,
              _pEnd;
    
        bool selectAll;
   
        int selIndex;

        public event EventHandler ImageUpdated;
        
        public Point StartPoint
        {
            get { return _pStart; }
            private set 
            { 
                _pStart = value; 
            }
        }
        public Point EndPoint
        {
            get { return _pEnd; }
            private set { _pEnd = value; }
        }

        public Image ImageCopy 
        { 
            get { return (Image)_pictureBox.Image.Clone(); }
        }

        public PictureBox PictureBox 
        {
            get { return _pictureBox; }
            private set { _pictureBox = value; }
        }

        public List<Figure> Figures 
        { 
            get 
            {
                return _figures; 
            }
            private set 
            { 
                _figures = value; 
            } 
        }
        public List<Point> Points 
        { 
            get { return _points; }
            private set { _points = value; }
        }

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
            selectAll = true;
            PictureBox.Refresh();
        }

        public void UpdateFigures()
        {
            using (var g = Graphics.FromImage(PictureBox.Image))
            {
                for (int i = 0; i < Figures.Count; i++)
                {
                    if (selIndex == i)
                        continue;
                    Figures[i].Erase(g, PaintAreaArgs.FillColor);
                    Figures[i].Draw(g);
                }
            }
        }

        public void DeleteSelected()
        {
            if (selIndex != -1)
            {
                using (var g = Graphics.FromImage(PictureBox.Image))
                {
                    Figures[selIndex].Erase(g, PaintAreaArgs.FillColor);
                }
                Figures.RemoveAt(selIndex);
                selIndex = -1;
            }

            UpdateFigures();
            PictureBox.Refresh();

            ImageUpdated?.Invoke(this, EventArgs.Empty);
        }

        public void RasterizeSelected()
        {
            if (selIndex != -1)
            {
                Figures.RemoveAt(selIndex);
                selIndex = -1;
            }

            UpdateFigures();
            PictureBox.Refresh();

            ImageUpdated?.Invoke(this, EventArgs.Empty);
        }

        public PaintArea Copy()
        {
            return new PaintArea(PictureBox.Image.Width, PictureBox.Image.Height, Figures.ToArray(),
                ImageCopy, PaintAreaArgs.Pen, PaintAreaArgs.FillColor);
        }

        public void FillArea(Color targetColor, Point p)
        {
            Bitmap bm = new Bitmap(PictureBox.Image);
            Color refColor = bm.GetPixel(p.X, p.Y);

            if (targetColor == refColor)
                return;

            Stack<Point> pixels = new Stack<Point>();
            Point check = p;
            pixels.Push(p);

            while (pixels.Count > 0)
            {
                Point pixel = pixels.Pop();
                if (pixel == check)
                {
                    pixels.Push(new Point(pixel.X - 1, pixel.Y));
                    pixels.Push(new Point(pixel.X + 1, pixel.Y));
                    pixels.Push(new Point(pixel.X, pixel.Y - 1));
                    pixels.Push(new Point(pixel.X, pixel.Y + 1));
                    continue;
                }

                if (pixel.X < bm.Width && pixel.X > 0 && pixel.Y < bm.Height && pixel.Y > 0)
                {
                    if (bm.GetPixel(pixel.X, pixel.Y) == refColor)
                    {
                        bm.SetPixel(pixel.X, pixel.Y, targetColor);
                        if (pixel.X - 1 != check.X)
                            pixels.Push(new Point(pixel.X - 1, pixel.Y));
                        if (pixel.X + 1 != check.X)
                            pixels.Push(new Point(pixel.X + 1, pixel.Y));
                        if (pixel.Y - 1 != check.Y)
                            pixels.Push(new Point(pixel.X, pixel.Y - 1));
                        if (pixel.Y - 1 != check.Y)
                            pixels.Push(new Point(pixel.X, pixel.Y + 1));

                        check = pixel;
                    }
                }
            }

            PictureBox.Image = bm;
        }

        #region Конструкторы

        private PaintArea()
        {
            PictureBox = new PictureBox();
            PictureBox.BackgroundImage = Properties.Resources.transparency;

            PictureBox.Location = new Point(0, 0);

            PictureBox.Paint += new PaintEventHandler(pictureBox_Paint);
            PictureBox.MouseMove += new MouseEventHandler(pictureBox_MouseMove);
            PictureBox.MouseDown += new MouseEventHandler(pictureBox_MouseDown);
            PictureBox.MouseUp += new MouseEventHandler(pictureBox_MouseUp);
            PictureBox.MouseLeave += new EventHandler(pictureBox_MouseLeave);

            Figures = new List<Figure>();
            Points = new List<Point>(4);
            selIndex = -1;
        }

        private PaintArea(Pen pen)
            : this()
        {
            PaintAreaArgs.SetPenWith(pen);
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
            PictureBox.Image = new Bitmap(image);
        }

        public PaintArea(int width, int height, Pen pen, Color bgClr)
            : this(width, height, pen)
        {
            PictureBox.BackColor = bgClr;
            PaintAreaArgs.FillColor = bgClr;

            using (var g = Graphics.FromImage(PictureBox.Image))
            {
                g.FillRectangle(new SolidBrush(bgClr), 0, 0, PictureBox.Width, PictureBox.Height);
            }
        }

        public PaintArea(int width, int height, Figure[] figures,
            Image image, Pen pen, Color bgColor)
            : this(width, height, pen, bgColor)
        {
            foreach (var fig in figures)
            {
                Figures.Add(fig.Copy());
            }
            using (var g = Graphics.FromImage(PictureBox.Image))
            {
                g.DrawImage(image, 0, 0, PictureBox.Width, PictureBox.Height);
            }

            UpdateFigures();
        }
        #endregion

        private void handler(Graphics g, bool saving)
        {
            Figure figure = null;

            switch (PaintAreaArgs.State)
            {
                case State.Cursor:
                    if (selIndex != -1 && saving)
                    {
                        if (Control.ModifierKeys == Keys.Shift)
                            Figures[selIndex].RedrawSymetricallyAt(EndPoint, g);
                        else
                            Figures[selIndex].RedrawAt(EndPoint, g);

                        UpdateFigures();
                        ImageUpdated?.Invoke(this, EventArgs.Empty);
                    }
                    else if (selIndex != -1)
                    {

                        Figure tempFig = Figures[selIndex].Copy();
                        if (Control.ModifierKeys == Keys.Shift)
                            tempFig.RedrawSymetricallyAt(EndPoint, g);
                        else
                            tempFig.RedrawAt(EndPoint, g);
                        tempFig.Select(g);

                        UpdateFigures();
                    }
                    break;
                case State.Brush:
                    figure = new BrushCurve(Points.ToArray(), PaintAreaArgs.ColoredBrushImage, PaintAreaArgs.Pen);
                    break;
                case State.Curve:
                    figure = new Curve(Points.ToArray(), PaintAreaArgs.Pen);
                    break;
                case State.Eraser:
                    figure = new Curve(Points.ToArray(), PaintAreaArgs.Eraser);
                    break;
                case State.Line:
                    figure = new Line(StartPoint, EndPoint, PaintAreaArgs.Pen);
                    break;
                case State.Rectangle:
                    figure = new Figures.Rectangle(StartPoint, EndPoint, PaintAreaArgs.Pen);
                    break;
                case State.Ellipse:
                    figure = new Ellipse(StartPoint, EndPoint, PaintAreaArgs.Pen);
                    break;
                case State.EllipsePie:
                    figure = new EllipsePie(StartPoint, EndPoint, PaintAreaArgs.PieStartAngle, PaintAreaArgs.PieSweepAngle, PaintAreaArgs.Pen);
                    break;
                case State.LineBezier:
                    Point middle = new Point((EndPoint.X + StartPoint.X) / 2,
                                             (EndPoint.Y + StartPoint.Y) / 2);
                    figure = new LineBezier(StartPoint, middle, middle, EndPoint, PaintAreaArgs.Pen);
                    break;
                case State.FillBucket:
                    if (saving)
                    {
                        FillArea(PaintAreaArgs.PenColor, EndPoint);
                    }
                    break;
                case State.SelectArea:
                    if (saving)
                    {
                        figure = new SelectAreaRect(StartPoint, EndPoint,  PictureBox.Image);
                    }
                    else
                    {
                        figure = new SelectAreaRect(StartPoint, EndPoint, null);
                    }
                    break;
            }

            if (figure != null)
            {
                if (PaintAreaArgs.State == State.Eraser)
                {
                    g.CompositingMode = CompositingMode.SourceCopy;
                    figure.Draw(g);
                    return;
                }

                if (Control.ModifierKeys == Keys.Shift)
                    figure.DrawSymetrically(g);
                else
                    figure.Draw(g);

                if (saving)
                    ImageUpdated?.Invoke(this, EventArgs.Empty);

                if (saving && PaintAreaArgs.State != State.Brush)
                    Figures.Insert(0, figure);
            }
        }

        #region События
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (selectAll == true)
            {
                foreach(var figure in Figures)
                {
                    figure.Select(e.Graphics);
                }
                selectAll = false;
                return;
            }

            handler(e.Graphics, false);
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            EndPoint = e.Location;

            if (EndPoint.X < 0)
                EndPoint = new Point(0, EndPoint.Y);
            if (EndPoint.Y < 0)
                EndPoint = new Point(EndPoint.X, 0);
            if (EndPoint.X > PictureBox.Width)
                EndPoint = new Point(PictureBox.Width, EndPoint.Y);
            if (EndPoint.Y > PictureBox.Height)
                EndPoint = new Point(EndPoint.X, PictureBox.Height);

            if (PaintAreaArgs.IsPainting)
            {
                if (PaintAreaArgs.State == State.SprayCurve)
                {
                    using (var g = Graphics.FromImage(PictureBox.Image))
                    {
                        Figure figure = new SprayCurve(EndPoint, PaintAreaArgs.SprayDistribution,
                            PaintAreaArgs.Pen);
                        figure.Draw(g);
                    }
                }

                Points.Add(EndPoint);
                PictureBox.Refresh();
            }
            else if (!PaintAreaArgs.IsPainting && 
                PaintAreaArgs.State == State.Brush || 
                PaintAreaArgs.State == State.Eraser ||
                PaintAreaArgs.State == State.Curve)
            {
                Points = new List<Point>() { EndPoint };
                PictureBox.Refresh();
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            StartPoint = e.Location;
            PaintAreaArgs.IsPainting = true;

            Points.Insert(0, StartPoint);

            if (PaintAreaArgs.State == State.Cursor)
            {
                for (int i = 0; i < Figures.Count; i++)
                {
                    if (Figures[i].Contains(StartPoint, 5))
                    {
                        selIndex = i;
                        Figures[selIndex].ReselectCorner(e.Location);
                        using (var g = Graphics.FromImage(PictureBox.Image))
                        {
                            Figures[selIndex].Erase(g, PaintAreaArgs.FillColor);
                        }
                        break;
                    }
                    else
                    {
                        if (Figures[i] is SelectAreaRect)
                        {
                            Figures.RemoveAt(i);
                        }
                        selIndex = -1;
                    }
                }
            }

            if (PaintAreaArgs.State == State.Delete)
            {
                for (int i = 0; i < Figures.Count; i++)
                {
                    if (Figures[i].Contains(StartPoint, 5))
                    {
                        using (var g = Graphics.FromImage(PictureBox.Image))
                        {
                            Figures[i].Erase(g, PaintAreaArgs.FillColor);
                            Figures.RemoveAt(i);
                        }
                        UpdateFigures();

                        ImageUpdated?.Invoke(this, EventArgs.Empty);
                        break;
                    }
                }
            }

            Points.Add(EndPoint);
            PictureBox.Refresh();
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {

            PaintAreaArgs.IsPainting = false;

            using (var g = Graphics.FromImage(PictureBox.Image))
            {
                handler(g, true);
            }

            if (PaintAreaArgs.State == State.SprayCurve)
                ImageUpdated?.Invoke(this, EventArgs.Empty);

            Points.Clear();
            UpdateFigures();
        }

        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (!PaintAreaArgs.IsPainting && 
                PaintAreaArgs.State == State.Brush || 
                PaintAreaArgs.State == State.Curve ||
                PaintAreaArgs.State == State.Eraser)
            {
                Points = new List<Point>();
                PictureBox.Refresh();
            }
        }
        #endregion
    }
}
