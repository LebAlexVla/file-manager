using FileManager.Core.Commands.CommandsAdditions.ConnectModes;
using FileManager.Core.Errors;
using FileManager.Core.FileSystems;

namespace FileManager.Core.Commands;

public class ConnectCommand : ICommand
{
    private readonly IConnectMode _connectMode;

    public ConnectCommand(IConnectMode connectMode)
    {
        _connectMode = connectMode;
    }

    public CommandResult Execute(IFileSystem? fileSystem, string? currentDirectory)
    {
        fileSystem = _connectMode.Create();

        if (fileSystem is not null)
        {
            currentDirectory = fileSystem.RootPath;

            return new CommandResult.Success();
        }

        return new CommandResult.Failure(new ExecutingError("Filesystem is null"));
    }
}