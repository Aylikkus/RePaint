using System.Drawing;

namespace RePaint.Figures
{
    public abstract class Figure
    {
        public Point Location { get; set; } // Первообразная точка фигуры
        public Point End { get; set; } // Конечнообразная точка фигуры
        public Size FigureSize { get; set; }
        public Pen FigurePen { get; set; }

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
    }
}
