using FileManager.Core.Commands.CommandsAdditions.Writing;
using FileManager.Core.CommandsExecuting;
using FileManager.Core.Errors;

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

    public CommandResult Execute(IContext context)
    {
        if (context.FileSystem is null || context.CurrentDirectory is null)
        {
            return new CommandResult.Failure(new ExecutingError("Problems with file system or current directory"));
        }

        string? content;
        try
        {
            string newPath = context.FileSystem.UpdatePath(context.CurrentDirectory, _path);
            if (!context.FileSystem.FileExists(newPath))
            {
                return new CommandResult.Failure(new ExecutingError("File not found"));
            }

            content = context.FileSystem.ReadFile(newPath);
        }
        catch (Exception ex)
        {
            return new CommandResult.Failure(new ExecutingError(ex.Message));
        }

        if (content is null)
        {
            return new CommandResult.Failure(new ExecutingError("No content"));
        }

        _writer.Write(content);

        return new CommandResult.Success();
    }
}