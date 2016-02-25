using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scene2d.Figures
{
    class RectangleFigure : IFigure
    {
        private Rectangle rectangle;

        public RectangleFigure(Point p1, Point p2)
        {
            this.rectangle.Vertex1 = p1;
            this.rectangle.Vertex2 = p2;
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public double CalulateArea()
        {
            return Math.Abs(this.rectangle.Vertex1.X - this.rectangle.Vertex2.X)
                    * Math.Abs(this.rectangle.Vertex1.Y - this.rectangle.Vertex2.Y);
        }

        public Rectangle CalculateCircumscribingRectangle()
        {
            return this.rectangle;
        }

        public void Move(Point vector)
        {
            this.rectangle.Vertex1 = this.rectangle.Vertex1 + vector;
            this.rectangle.Vertex2 = this.rectangle.Vertex2 + vector;
        }

        public void Rotate(double angle)
        {
            /*var center = new Point
                             {
                                 X =
                                     Math.Min(this.rectangle.Vertex1.X, this.rectangle.Vertex2.X)
                                     + (Math.Abs(this.rectangle.Vertex1.X - this.rectangle.Vertex2.X) / 2),
                                 Y =
                                     Math.Min(this.rectangle.Vertex1.Y, this.rectangle.Vertex2.Y)
                                     + (Math.Abs(this.rectangle.Vertex1.Y - this.rectangle.Vertex2.Y) / 2)
                             };
            this.rectangle.Vertex1 = */
            throw new NotImplementedException();
        }
    }
}
