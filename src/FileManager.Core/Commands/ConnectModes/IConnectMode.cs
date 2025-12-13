using FileManager.Core.FileSystems;

namespace FileManager.Core.Commands.ConnectModes;

public interface IConnectMode
{
    IFileSystem Create();
}