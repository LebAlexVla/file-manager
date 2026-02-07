using FileManager.Core.Commands.CommandsAdditions.Writing;
using FileManager.Core.Errors;
using FileManager.Core.FileSystems;

namespace FileManager.Core.Commands;

public class FileShowCommand : ICommand
{
    private readonly IWriter _writer;
    private readonly string _path;

    public FileShowCommand(IWriter writer, string path)
    {
        _writer = writer;
        _path = path;
    }

    public CommandResult Execute(IFileSystem? fileSystem, string? currentDirectory)
    {
        if (fileSystem is null || currentDirectory is null)
        {
            return new CommandResult.Failure(new ExecutingError("Problems with file system or current directory"));
        }

        string newPath = fileSystem.UpdatePath(currentDirectory, _path);
        string? content = fileSystem.ReadFile(newPath);
        if (content is null)
        {
            return new CommandResult.Failure(new ExecutingError("No content"));
        }

        _writer.Write(content);

        return new CommandResult.Success();
    }
}