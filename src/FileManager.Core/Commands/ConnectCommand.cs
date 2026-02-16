using FileManager.Core.Commands.CommandsAdditions.ConnectModes;
using FileManager.Core.CommandsExecuting;
using FileManager.Core.Errors;

namespace FileManager.Core.Commands;

public class ConnectCommand : ICommand
{
    private readonly IConnectMode _connectMode;

    public ConnectCommand(IConnectMode connectMode, string address)
    {
        _connectMode = connectMode;
        _connectMode.Path = address;
    }

    public CommandResult Execute(IContext context)
    {
        context.FileSystem = _connectMode.Create();

        if (context.FileSystem is not null)
        {
            context.CurrentDirectory = context.FileSystem.RootPath;

            return new CommandResult.Success();
        }

        return new CommandResult.Failure(new ExecutingError("Filesystem is null"));
    }
}