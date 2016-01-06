namespace Scene2d
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IFigure : ICloneable
    {
        double CalulateArea();

        Rectangle CalculateCircumscribingRectangle();

        void Move(Point vector);

        void Rotate(double angle);
    }
}
