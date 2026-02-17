using FileManager.Core.CommandsExecuting;
using FileManager.Core.Errors;

namespace FileManager.Core.Commands;

public class FileDeleteCommand : ICommand
{
    private string _path;

    public FileDeleteCommand(string path)
    {
        _path = path;
    }

    public CommandResult Execute(IContext context)
    {
        if (context.FileSystem is null || context.CurrentDirectory is null)
        {
            return new CommandResult.Failure(new ExecutingError("Problems with file system or current directory"));
        }

        try
        {
            _path = context.FileSystem.UpdatePath(context.CurrentDirectory, _path);
            if (!context.FileSystem.FileExists(_path))
            {
                return new CommandResult.Failure(new ExecutingError("File not found"));
            }

            context.FileSystem.DeleteFile(_path);
        }
        catch (Exception ex)
        {
            return new CommandResult.Failure(new ExecutingError(ex.Message));
        }

        return new CommandResult.Success();
    }
}