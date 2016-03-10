namespace Scene2d.Figures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CompositeFigure : ICompositeFigure
    {
        public CompositeFigure(Dictionary<string, IFigure> childFigures)
        {
            this.ChildFigures = childFigures;
        }

        public Dictionary<string, IFigure> ChildFigures { get; }

        public object Clone()
        {
           return this.ChildFigures.ToDictionary(figures => figures.Key, figures => figures.Value);
        }

        public double CalulateArea()
        {
            return this.ChildFigures.Values.Sum(figures => figures.CalulateArea());
        }

        public Rectangle CalculateCircumscribingRectangle()
        {
            var minx = double.MaxValue;
            var miny = double.MaxValue;
            var maxy = double.MinValue;
            var maxx = double.MinValue;
            foreach (var figures in this.ChildFigures.Values)
            {
                maxx = Math.Max(figures.CalculateCircumscribingRectangle().Vertex1.X, maxx);
                minx = Math.Min(figures.CalculateCircumscribingRectangle().Vertex1.X, minx);
                maxy = Math.Max(figures.CalculateCircumscribingRectangle().Vertex1.X, maxy);
                miny = Math.Min(figures.CalculateCircumscribingRectangle().Vertex1.X, miny);
            }

            var minPoint = new Point { X = minx, Y = miny };
            var maxPoint = new Point { X = maxx, Y = maxy };
            return new Rectangle { Vertex1 = minPoint, Vertex2 = maxPoint };
        }

        public void Move(Point vector)
        {
            foreach (var figures in this.ChildFigures.Values)
            {
                figures.Move(vector);
            }         
        }

        public void Rotate(double angle)
        {
            foreach (var figures in this.ChildFigures.Values)
            {
                figures.Rotate(angle);
            }
        }
    }
}
