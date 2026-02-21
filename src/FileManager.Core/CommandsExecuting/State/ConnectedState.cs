using FileManager.Core.FileSystems;

namespace FileManager.Core.CommandsExecuting.State;

public class ConnectedState : IContextState
{
    private readonly Context _context;

    public ConnectedState(Context context, IFileSystem fileSystem, string currentDirectory)
    {
        _context = context;
        FileSystem = fileSystem;
        CurrentDirectory = currentDirectory;
    }

    public IFileSystem FileSystem { get; init; }

    public string CurrentDirectory { get; set; }

    public bool TryConnect(IFileSystem fileSystem, string address)
    {
        return false;
    }

    public bool TryDisconnect()
    {
        _context.ChangeState(new DisconnectedState(_context));

        return true;
    }
}