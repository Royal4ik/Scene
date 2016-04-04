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
            if (!this.compositeFigures.ContainsKey(name) && !this.figures.ContainsKey(name))
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
            var figureDictionary = new Dictionary<string, IFigure>();
            foreach (var figureName in childFigures)
            {
                if (this.figures.ContainsKey(figureName))
                {
                    figureDictionary.Add(figureName, this.figures[figureName]);
                }
                else
                {
                    throw new Exception("Данного имени не существует в рамках сцены");
                }
            }

            this.compositeFigures.Add(name, new CompositeFigure(figureDictionary));
        }

        public void DeleteFigure(string name)
        {
            if (this.compositeFigures.ContainsKey(name))
            {
                foreach (var childFigures in this.compositeFigures[name].ChildFigures)
                {
                    this.figures.Remove(childFigures.Key);
                }
                
                this.compositeFigures.Remove(name);
            }
            else if (this.figures.ContainsKey(name))
            {
                this.figures.Remove(name);
            }
            else if (name == "Scene")
            {
                foreach (var figure in this.figures.Keys)
                {
                    this.figures.Remove(figure);
                }

                foreach (var compositivefigure in this.compositeFigures.Keys)
                {
                    this.compositeFigures.Remove(compositivefigure);
                }
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

            if (this.figures.ContainsKey(name))
            {
                return this.figures[name].CalulateArea();
            }

            throw new Exception("Данного имени не существует");
        }

        public Rectangle CalculateCircumscribingRectangle(string name)
        {
            if (this.compositeFigures.ContainsKey(name))
            {
                return this.compositeFigures[name].CalculateCircumscribingRectangle();
            }

            if (this.figures.ContainsKey(name))
            {
                return this.figures[name].CalculateCircumscribingRectangle();
            }

            throw new Exception("Данного имени не существует");
        }

        public void Move(string name, Point vector)
        {
            if (this.compositeFigures.ContainsKey(name))
            {
                this.compositeFigures[name].Move(vector);
            }
            else if (this.figures.ContainsKey(name))
            {
                this.figures[name].Move(vector);
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
            else if (this.figures.ContainsKey(name))
            {
                this.figures[name].Rotate(angle);
            }
            else
            {
                throw new Exception("Данного имени не существует");
            }
        }

        public void Copy(string name, string copyName)
        {
            if (this.compositeFigures.ContainsKey(name))
            {
                foreach (var childFigures in this.compositeFigures[name].ChildFigures)
                {
                    this.figures.Add(childFigures.Key+"_copy", (IFigure)childFigures.Value.Clone() );
                }

                this.compositeFigures.Add(copyName, (ICompositeFigure)this.compositeFigures[name].Clone());
            }
            else if (this.figures.ContainsKey(name))
            {
                this.figures.Add(copyName, (IFigure)this.figures[name].Clone());
            }
            else if (name == "Scene")
            {
                foreach (var figure in this.figures.Keys)
                {
                    this.figures.Add(figure + "_copy", (IFigure)this.figures[figure].Clone());
                }
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
