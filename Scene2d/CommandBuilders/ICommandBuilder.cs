namespace Scene2d
{
    using Scene2d.Commands;

    public interface ICommandBuilder
    {
        bool IsCommandReady { get; }

        void AppendLine(string line);

        ICommand GetCommand();
    }
}
