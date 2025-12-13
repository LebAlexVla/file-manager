using FileManager.Core.FileSystems;

namespace FileManager.Core.Commands.CommandsAdditions.ConnectModes;

public class LocalConnectMode : IConnectMode
{
    public string? Path { get; set; }

    public IFileSystem? Create()
    {
        return Path != null ? new LocalFileSystem(Path) : null;
    }
}