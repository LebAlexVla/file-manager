using FileManager.Core.CommandsExecuting.State;
using FileManager.Core.FileSystems;

namespace FileManager.Core.CommandsExecuting;

public class Context
{
    public Context()
    {
        State = new DisconnectedState(this);
    }

    public IContextState State { get; private set; }

    public bool TryConnect(IFileSystem fileSystem, string address)
    {
        return State.TryConnect(fileSystem, address);
    }

    public bool TryDisconnect()
    {
        return State.TryDisconnect();
    }

    public void ChangeState(IContextState state)
    {
        State = state;
    }
}