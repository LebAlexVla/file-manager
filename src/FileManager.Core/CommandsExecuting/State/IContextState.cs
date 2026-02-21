using FileManager.Core.FileSystems;

namespace FileManager.Core.CommandsExecuting.State;

public interface IContextState
{
    bool TryConnect(IFileSystem fileSystem, string address);

    bool TryDisconnect();
}