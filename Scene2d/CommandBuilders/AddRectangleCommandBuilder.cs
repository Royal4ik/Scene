namespace Scene2d
{
    using System.Text.RegularExpressions;

    using Scene2d.Commands;
    using Scene2d.Figures;

    public class AddRectangleCommandBuilder : ICommandBuilder
    {
        private static Regex recognizeRegex = new Regex("//regex to recognize all parameters of ad rectangle command");

        private RectangleFigure rectangle;

        private string name;

        public bool IsCommandReady
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public void AppendLine(string line)
        {
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
            return new AddFigureCommand(name, this.rectangle);
        }
    }
}