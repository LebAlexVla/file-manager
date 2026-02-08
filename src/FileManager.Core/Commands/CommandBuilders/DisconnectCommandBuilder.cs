namespace FileManager.Core.Commands.CommandBuilders;

public class DisconnectCommandBuilder : ICommandBuilder
{
    public ICommand Build()
    {
        return new DisconnectCommand();
    }
}