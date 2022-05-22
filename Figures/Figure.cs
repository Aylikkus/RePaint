using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace RePaint.Figures
{
    [Serializable]
    public abstract class Figure
    {
        [NonSerialized]
        protected Pen _figurePen;

        protected Color _figureColor;
        protected float _figureWidth;
        protected DashStyle _figureDashStyle;

        public Point Location { get; set; } // Первообразная точка фигуры
        public Point End { get; set; } // Конечнообразная точка фигуры
        public Size FigureSize { get; set; }

        public Pen FigurePen 
        { 
            get 
            { 
                _figurePen = new Pen(FigureColor, FigureWidth);
                _figurePen.DashStyle = FigureDashStyle;
                return _figurePen; 
            }
        }

        public Color FigureColor 
        { 
            get { return _figureColor; }
            set { _figureColor = value; }
        }
        public float FigureWidth
        {
            get { return _figureWidth; }
            set { _figureWidth = value; }
        }
        public DashStyle FigureDashStyle
        {
            get { return _figureDashStyle; }
            set { _figureDashStyle = value; }
        }

        public Figure Copy()
        {
            return (Figure)MemberwiseClone();
        }

        public abstract void Update();
        public abstract void Draw(Graphics g);
        public abstract void DrawSymetrically(Graphics g);
        public abstract void Select(Graphics g);
        public abstract void ReselectCorner(Point point);
        public abstract void Erase(Graphics g, Color eraseClr);
        public abstract void RedrawAt(Point point, Graphics g);
        public abstract void RedrawSymetricallyAt(Point point, Graphics g);
        public abstract bool Contains(Point point, int offset = 0);

        public Figure(Pen p)
        {
            FigureColor = p.Color;
            FigureWidth = p.Width;
            FigureDashStyle = p.DashStyle;
        }
    }
}
