namespace Scene2d
{
    using System;
    using System.Net;
    using System.Text.RegularExpressions;

    using Scene2d.Commands;
    using Scene2d.Exceptions;
    using Scene2d.Figures;

    public class AddRectangleCommandBuilder : ICommandBuilder
    {
        private static Regex recognizeRegex = new Regex(@"\w+\s\w+\s+([\w\d-_]+)\s+\((\d)+\,\s+(\d+)\)\s+\((\d)+\,\s+(\d+)\)\s*(#|\s*$)");

        private RectangleFigure rectangle;

        private string name;

        public bool IsCommandReady
        {
            get
            {
                return true;
            }
        }

        public void AppendLine(string line)
        {
            const double Eps = 0.00001;
            if (recognizeRegex.IsMatch(line))
            {
                var match = recognizeRegex.Match(line);
                while (match.Success)
                {
                    var x1 = Convert.ToDouble(match.Groups[2].Value);
                    var y1 = Convert.ToDouble(match.Groups[3].Value);
                    var x2 = Convert.ToDouble(match.Groups[4].Value);
                    var y2 = Convert.ToDouble(match.Groups[5].Value);
                    if ((Math.Abs(x1 - x2) > Eps) && (Math.Abs(y1 - y2) > Eps))
                    {
                        var p1 = new Point
                        {
                            X = x1,
                            Y = y1
                        };
                        var p2 = new Point
                        {
                            X = x2,
                            Y = y2
                        };

                        this.rectangle = new RectangleFigure(p1, p2);
                        this.name = match.Groups[1].Value;
                        match = match.NextMatch();
                    }
                    else
                    {
                        throw new BadRectanglePointException("Точки не задают прямоугольник");
                    }            
                }
            }
            else
            {
                throw new BadFormatException("Неправильный формат ввода данных");
            }

            // check recognizeRegex
            //
            // if correct select params of rectangle
            // this.name = ...
            // this.rectangle = new Rectangle(p1, p2)
            //
            // if not correct throw BadFormatException
        }

        public ICommand GetCommand()
        {
            return new AddFigureCommand(this.name, this.rectangle);
        }
    }
}