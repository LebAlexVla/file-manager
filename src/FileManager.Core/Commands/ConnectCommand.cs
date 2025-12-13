using FileManager.Core.Commands.ConnectModes;
using FileManager.Core.FileSystems;

namespace FileManager.Core.Commands;

public class ConnectCommand : ICommand
{
    private readonly string _address;

    private readonly IConnectMode _connectMode;

    public ConnectCommand(string address, IConnectMode connectMode)
    {
        _address = address;
        _connectMode = connectMode;
    }

    public CommandResult Execute(IFileSystem? fileSystem, string? currentPath)
    {
        fileSystem = _connectMode.Create();
        currentPath = _address;

        return new CommandResult.Success();
    }
}