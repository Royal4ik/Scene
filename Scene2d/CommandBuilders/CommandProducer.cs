namespace Scene2d.CommandBuilders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    using Scene2d.Commands;
    using Scene2d.Exceptions;

    public class CommandProducer : ICommandBuilder
    {
        private static Dictionary<Regex, Func<ICommandBuilder>> commands =
            new Dictionary<Regex, Func<ICommandBuilder>>
            {
                { new Regex("^add rectangle .*"), () => new AddRectangleCommandBuilder() }  // распознает и передает в в билдер (словарь команд)
            };

        private ICommandBuilder currentBuilder;

        public bool IsCommandReady
        {
            get
            {
                if (this.currentBuilder == null)
                {
                    return false;
                }

                return this.currentBuilder.IsCommandReady;
            }
        }

        public void AppendLine(string line)
        {
            var isException = true;
            if (this.currentBuilder == null)
            {
                foreach (var pair in commands.Where(pair => pair.Key.IsMatch(line)))
                {
                    isException = false;
                    this.currentBuilder = pair.Value();
                    break;
                }
            }

            if (isException)
            {
                throw new BadFormatException("Неправильный формат ввода данных");
            }

            this.currentBuilder.AppendLine(line);
        }

        public ICommand GetCommand()
        {
            if (this.currentBuilder == null)
            {
                return null;
            }

            var command = this.currentBuilder.GetCommand();
            this.currentBuilder = null;

            return command;
        }
    }
}
