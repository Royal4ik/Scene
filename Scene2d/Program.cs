namespace Scene2d
{
    // начнем с прохождения отладчика по прямоугольнику
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Scene2d.Exceptions;

    internal class Program
    {
        internal static void Main(string[] args)
        {
            var commandProducer = new CommandProducer();
            var scene = new Scene();

            while (true)
            {
                string line = Console.ReadLine();
                System.String.Compare(line, "das", System.StringComparison.Ordinal);
                if (line == null || line.Trim().Length == 0)
                {
                    break;
                }

                try
                {
                    commandProducer.AppendLine(line);

                    if (commandProducer.IsCommandReady)  //распознает одно- или многострочную программу
                    {
                        var command = commandProducer.GetCommand();
                        command.Apply(scene);
                    }
                }
                catch(BadFormatException)
                {
                    // out line number and error text
                    // пользовательские exceptions (catch)
                }

                // another exceptions handling
            }
        }
    }
}
