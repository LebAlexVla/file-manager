using FileManager.Core.FileSystems;

namespace FileManager.Core.CommandsExecuting.State;

public class DisconnectedState : IContextState
{
    private readonly Context _context;

    public DisconnectedState(Context context)
    {
        _context = context;
    }

    public bool TryConnect(IFileSystem fileSystem, string address)
    {
        if (!fileSystem.DirectoryExists(address))
            return false;

        _context.ChangeState(new ConnectedState(_context, fileSystem, address));

        return true;
    }

    public bool TryDisconnect()
    {
        return false;
    }
}