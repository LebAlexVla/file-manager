using FileManager.Core.Errors;
using FileManager.Core.FileSystems;

namespace FileManager.Core.Commands;

public class TreeGotoCommand : ICommand
{
    private readonly string _path;

    public TreeGotoCommand(string path)
    {
        _path = path;
    }

    public CommandResult Execute(IFileSystem? fileSystem, string? currentDirectory)
    {
        if (fileSystem is null || currentDirectory is null)
        {
            return new CommandResult.Failure(new ExecutingError("Problems with file system or current directory"));
        }

        currentDirectory = fileSystem.UpdatePath(currentDirectory, _path);

        return new CommandResult.Success();
    }
}