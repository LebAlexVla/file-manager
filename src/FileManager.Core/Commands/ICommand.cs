using FileManager.Core.FileSystems;

namespace FileManager.Core.Commands;

public interface ICommand
{
    CommandResult Execute(IFileSystem? fileSystem, string? currentDirectory);
}