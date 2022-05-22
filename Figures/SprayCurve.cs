using System;
using System.Drawing;

namespace RePaint.Figures
{
    [Serializable]
    class SprayCurve : Curve
    {
        float distribution;
        public override void Draw(Graphics g)
        {
            Random rnd = new Random();
            int radius = (int)FigureWidth / 2;

            for (int i = 0; i < distribution * FigurePen.Width * 4; ++i)
            {
                // Выбираем полярные координаты
                // где theta это случайный угол между 0..2*PI
                // и r случайное число между 0..radius
                double theta = rnd.NextDouble() * (Math.PI * 2);
                double r = rnd.NextDouble() * radius;

                // Преобразуем полярные координаты в декартовы (x,y)
                // и переводим центр к текущей позиции мыши
                double x = points[points.Length - 1].X + Math.Cos(theta) * r;
                double y = points[points.Length - 1].Y + Math.Sin(theta) * r;

                g.DrawEllipse(new Pen(FigureColor, 1), new System.Drawing.Rectangle((int)x - 1, (int)y - 1, 1, 1));
            }
        }

        public SprayCurve(Point point, float distribution, Pen pen)
            : base(new Point[] { point }, pen)
        {
            this.distribution = distribution;
        }
    }
}
