using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scene2d.Figures
{
    class RectangleFigure : IFigure
    {
        public RectangleFigure(Point p1, Point p2)
        {
            
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
    }
}
