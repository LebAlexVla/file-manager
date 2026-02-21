using FileManager.Core.FileSystems;

namespace FileManager.Core.Commands.CommandsAdditions.ConnectModes;

public class LocalConnectMode : IConnectMode
{
    public IFileSystem Create(string address)
    {
        return new LocalFileSystem(address);
    }
}