using FileManager.Core.FileSystems;

namespace FileManager.Core.Commands.CommandsAdditions.ConnectModes;

public interface IConnectMode
{
    IFileSystem Create(string address);
}