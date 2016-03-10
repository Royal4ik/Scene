namespace Scene2d
{
    using System;
    using System.Collections.Generic;

    using Scene2d.Figures;

    public class Scene
    {
        // possible implementation of figures storage
        // feel free to use your own!
        private readonly Dictionary<string, IFigure> figures =
            new Dictionary<string, IFigure>();

        private readonly Dictionary<string, ICompositeFigure> compositeFigures =
            new Dictionary<string, ICompositeFigure>();

        public void AddFigure(string name, IFigure figure)
        {
            if (!this.compositeFigures.ContainsKey(name))
            {
                this.figures.Add(name, figure);
            }
            else
            {
                throw new Exception("Данное имя уже существует");
            }
        }

        public void CreateCompositeFigure(string name, IEnumerable<string> childFigures)
        {
            //this.compositeFigures.Add(name, childFigures);
        }

        public void DeleteFigure(string name)
        {
            if (this.compositeFigures.ContainsKey(name))
            {
                this.figures.Remove(name);
            }
            else
            {
                throw new Exception("Данного имени не существует");
            }
        }

        public double CalulateArea(string name)
        {
            if (this.compositeFigures.ContainsKey(name))
            {
                return this.compositeFigures[name].CalulateArea();
            }
            else
            {
                throw new Exception("Данного имени не существует");
            }
        }

        public Rectangle CalculateCircumscribingRectangle(string name)
        {
            if (this.compositeFigures.ContainsKey(name))
            {
                return this.compositeFigures[name].CalculateCircumscribingRectangle();
            }
            else
            {
                throw new Exception("Данного имени не существует");
            }
        }

        public void Move(string name, Point vector)
        {
            if (this.compositeFigures.ContainsKey(name))
            {
                this.compositeFigures[name].Move(vector);
            }
            else
            {
                throw new Exception("Данного имени не существует");
            }
        }

        public void Rotate(string name, double angle)
        {
            if (this.compositeFigures.ContainsKey(name))
            {
                this.compositeFigures[name].Rotate(angle);
            }
            else
            {
                throw new Exception("Данного имени не существует");
            }
        }

        // another methods for figures manipulation
        // adding, removing etc
    }
}
