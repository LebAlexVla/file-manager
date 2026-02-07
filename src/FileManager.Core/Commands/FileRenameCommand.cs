using FileManager.Core.Errors;
using FileManager.Core.FileSystems;

namespace FileManager.Core.Commands;

public class FileRenameCommand : ICommand
{
    private readonly string _path;
    private readonly string _name;

    public FileRenameCommand(string path, string name)
    {
        _path = path;
        _name = name;
    }

    public CommandResult Execute(IFileSystem? fileSystem, string? currentDirectory)
    {
        if (fileSystem is null || currentDirectory is null)
        {
            return new CommandResult.Failure(new ExecutingError("Problems with file system or current directory"));
        }

        fileSystem.RenameFile(_path, _name);

        return new CommandResult.Success();
    }
}