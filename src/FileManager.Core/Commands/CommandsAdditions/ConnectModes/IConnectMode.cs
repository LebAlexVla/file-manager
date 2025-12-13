using FileManager.Core.FileSystems;

namespace FileManager.Core.Commands.CommandsAdditions.ConnectModes;

public interface IConnectMode
{
    string? Path { get; set; }

    IFileSystem? Create();
}