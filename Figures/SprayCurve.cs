﻿using System;
using System.Drawing;

namespace RePaint.Figures
{
    class SprayCurve : Curve
    {
        float distribution;
        public override void Draw(Graphics g)
        {
            Random rnd = new Random();
            int radius = (int)FigurePen.Width / 2;

            for (int i = 0; i < distribution * 100; ++i)
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

                g.DrawEllipse(new Pen(FigurePen.Color, 1), new System.Drawing.Rectangle((int)x - 1, (int)y - 1, 1, 1));
            }
        }

        public SprayCurve(Point[] points, float distribution, Pen pen)
            : base(points, pen)
        {
            this.distribution = distribution;
        }
    }
}
