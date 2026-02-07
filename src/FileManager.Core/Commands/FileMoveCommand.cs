using FileManager.Core.Errors;
using FileManager.Core.FileSystems;

namespace FileManager.Core.Commands;

public class FileMoveCommand : ICommand
{
    private readonly string _sourcePath;
    private readonly string _destinationPath;

    public FileMoveCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public CommandResult Execute(IFileSystem? fileSystem, string? currentDirectory)
    {
        if (fileSystem is null || currentDirectory is null)
        {
            return new CommandResult.Failure(new ExecutingError("Problems with file system or current directory"));
        }

        fileSystem.MoveFile(_sourcePath, _destinationPath);

        return new CommandResult.Success();
    }
}