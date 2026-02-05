namespace FileManager.Core.Commands.CommandBuilders;

public class DisconnectCommandBuilder : ICommandBuilder
{
    public CommandBuildResult Build()
    {
        return new CommandBuildResult.Success(new DisconnectCommand());
    }
}