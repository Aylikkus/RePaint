using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using RePaint.Figures;
using System.Collections.Generic;

namespace RePaint.Utils
{
    static class PaintAreaArgs
    {
        static Pen _pen;
        static Pen _eraser;
        static Image _brushImage;
        static Image _coloredBrushImage;
        static Color _fillColor;

        static float _sprayDistribution;
        static bool _isPainting;

        public static State State { get; set; }

        public static event EventHandler ColorChanged;

        public static Image PrimaryBrushImage 
        { 
            get { return _brushImage; }
            set
            {
                _brushImage = value;
                UpdateColoredBrushImage();
            }
        }
        public static Image ColoredBrushImage 
        { 
            get { return _coloredBrushImage; }
        }

        public static float PaintWidth
        {
            get { return _pen.Width; }
            set 
            {
                _pen.Width = value;
                _eraser.Width = value;
            }
        }

        public static Color PenColor
        { 
            get { return _pen.Color; }
            set 
            {
                _pen.Color = value;  
                UpdateColoredBrushImage();
                ColorChanged?.Invoke(typeof(PaintAreaArgs), EventArgs.Empty);
            }
        }

        public static DashStyle PenDashStyle
        {
            get { return _pen.DashStyle; }
            set { _pen.DashStyle = value; }
        }

        public static Pen Pen 
        { 
            get { return (Pen)_pen.Clone(); }
        }

        public static Pen Eraser 
        { 
            get { return (Pen)_eraser.Clone(); }
        }

        public static Color FillColor 
        { 
            get { return _fillColor; }
            set{ _fillColor = value; }
        }

        public static float SprayDistribution 
        { 
            get { return _sprayDistribution; }
            set { _sprayDistribution = value; }
        }
        public static float PieStartAngle { get; set; }
        public static float PieSweepAngle { get; set; }

        public static bool IsPainting 
        { 
            get { return _isPainting; } 
            set { _isPainting = value; }
        }

        public static void UpdateColoredBrushImage()
        {
            var ImageAttributes = new ImageAttributes();
            ColorMap[] colorMap = new ColorMap[256];
            colorMap[0] = new ColorMap();

            for (int i = 1; i < 256; i++)
            {
                colorMap[i] = new ColorMap();
                colorMap[i].OldColor = Color.FromArgb(i, Color.Black);
                colorMap[i].NewColor = Pen.Color;
            }

            ImageAttributes.SetRemapTable(colorMap);

            Image newBitmap = new Bitmap(PrimaryBrushImage.Width, PrimaryBrushImage.Height);
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                var rect = new System.Drawing.Rectangle(
                new Point(0, 0), PrimaryBrushImage.Size);

                g.DrawImage(PrimaryBrushImage, rect, 0, 0, rect.Width, rect.Height,
                    GraphicsUnit.Pixel, ImageAttributes);
            }

            _coloredBrushImage = newBitmap;
        }

        public static void SetPenWith(Pen pen)
        {
            PenColor = pen.Color;
            PenDashStyle = pen.DashStyle;
            PaintWidth = pen.Width;
        }

        public static void Serialize(string path, PaintArea pa)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, pa.ImageCopy);
                foreach(var figure in pa.Figures)
                {
                    formatter.Serialize(fs, figure.Copy());
                }
                fs.Flush();
                fs.Close();
            }
        }

        public static PaintArea Deserialize(string path)
        {
            Image desImg;
            List<Figure> figures = new List<Figure>();
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    desImg = (Image)formatter.Deserialize(fs);
                }
                catch (SerializationException)
                {
                    throw new SerializationException();
                }
                while (fs.Position != fs.Length)
                {
                    figures.Add((Figure)formatter.Deserialize(fs));
                }
                fs.Close();
            }
            return new PaintArea(desImg.Width, desImg.Height, 
                figures.ToArray(), (Image)desImg.Clone(), Pen, FillColor);
        }

        static PaintAreaArgs()
        {
            _pen = (Pen)Pens.Black.Clone();
            _eraser = (Pen)Pens.Transparent.Clone();
            _brushImage = (Image)Properties.Resources.SolidBrush.Clone();
            _fillColor = Color.White;

            _sprayDistribution = 0.5f;
            _isPainting = false;

            UpdateColoredBrushImage();
        }
    }
}
