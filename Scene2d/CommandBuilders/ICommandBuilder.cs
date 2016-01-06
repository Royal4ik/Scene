using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Scene2d
{
    public interface ICommandBuilder
    {
        bool IsCommandReady { get; }

        void AppendLine(string line);

        ICommand GetCommand();
    }
}
