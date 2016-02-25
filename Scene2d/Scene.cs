using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scene2d
{
    using Scene2d.Figures;

    public class Scene
    {
        // possible implementation of figures storage
        // feel free to use your own!
        private Dictionary<string, IFigure> figures =
            new Dictionary<string, IFigure>();

        private Dictionary<string, ICompositeFigure> compositeFigures =
            new Dictionary<string, ICompositeFigure>();

        public void AddFigure(string name, IFigure figure)
        {
            this.figures.Add(name, figure);
        }

        public void CreateCompositeFigure(string name, IEnumerable<string> childFigures)
        {
            //this.compositeFigures.Add(name, childFigures);
        }

        public void DeleteFigure(string name)
        {
            this.figures.Remove(name);
        }

        public double CalulateArea(string name)
        {
            throw new NotImplementedException();
        }

        public Rectangle CalculateCircumscribingRectangle(string name)
        {
            throw new NotImplementedException();
        }


        public void Move(string name, Point vector)
        {
            
        }

        public void Rotate(string name, double angle)
        {
            
        }

        // another methods for figures manipulation
        // adding, removing etc
    }
}
