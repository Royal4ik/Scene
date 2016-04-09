namespace Scene2d.Figures
{
    using System;
    using System.Collections.Generic;

    public class PolygonFigure : IFigure
    {
        private List<Point> polygon;

        public PolygonFigure(List<Point> polygon)
        {
            this.polygon = polygon;
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public double CalulateArea()
        {
            throw new NotImplementedException();
        }

        public Rectangle CalculateCircumscribingRectangle()
        {
            throw new NotImplementedException();
        }

        public void Move(Point vector)
        {
            throw new NotImplementedException();
        }

        public void Rotate(double angle)
        {
            throw new NotImplementedException();
        }

        public void Reflect(bool isUpright)
        {
            throw new NotImplementedException();
        }
    }
}
