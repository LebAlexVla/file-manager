using FileManager.Core.FileSystems;

namespace FileManager.Core.CommandsExecuting;

public interface IContext
{
    IFileSystem? FileSystem { get; set; }

    string? CurrentDirectory { get; set; }
}