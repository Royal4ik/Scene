namespace Scene2d
{
    // начнем с прохождения отладчика по прямоугольнику
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    using Scene2d.Exceptions;

    internal class Program
    {
        internal static void Main(string[] args)
        {
            var commandProducer = new CommandProducer();
            var scene = new Scene();
            using (var source = new StreamReader("Data/commands.txt", Encoding.UTF8))
            {
                // initializes colors
                string input;
                var numberLine = 0;
                while ((input = source.ReadLine()) != null)
                {
                    if (input.Trim().Length == 0)
                    {
                        break;                       
                    }

                    numberLine++;

                    try
                    {
                        if (input.Trim()[0] == '#')
                        {
                            continue;
                        }

                        commandProducer.AppendLine(input);

                        if (commandProducer.IsCommandReady)
                        {
                            // распознает одно- или многострочную программу
                            var command = commandProducer.GetCommand();
                            command.Apply(scene);
                        }
                    }
                    catch (BadFormatException ex)
                    {
                        Console.WriteLine("Произошла ошибка: " + ex.Message + "в строке - " + numberLine);
                        // out line number and error text
                        // пользовательские exceptions (catch)
                    }
                    catch (BadRectanglePointException ex)
                    {
                        Console.WriteLine("Произошла ошибка: " + ex.Message + "в строке - " + numberLine);
                    }
                }

                // another exceptions handling
            }
        }
    }
}
