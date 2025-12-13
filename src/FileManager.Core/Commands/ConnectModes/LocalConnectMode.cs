using FileManager.Core.FileSystems;

namespace FileManager.Core.Commands.ConnectModes;

public class LocalConnectMode : IConnectMode
{
    public IFileSystem Create()
    {
        throw new NotImplementedException();
    }
}