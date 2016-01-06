namespace Scene2d
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using System.Text.RegularExpressions;

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
            if (this.currentBuilder == null)
            {
                foreach (var pair in commands)
                {
                    if (pair.Key.IsMatch(line))
                    {
                        this.currentBuilder = pair.Value();
                        break;
                    }
                }
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
