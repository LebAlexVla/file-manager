using FileManager.Core.CommandsExecuting;
using FileManager.Core.Errors;

namespace FileManager.Core.Commands;

public class TreeGotoCommand : ICommand
{
    private readonly string _path;

    public TreeGotoCommand(string path)
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
            string directory = context.FileSystem.UpdatePath(context.CurrentDirectory, _path);
            if (!context.FileSystem.DirectoryExists(directory))
            {
                return new CommandResult.Failure(new ExecutingError("Directory does not exist"));
            }

            context.CurrentDirectory = directory;
        }
        catch (Exception ex)
        {
            return new CommandResult.Failure(new ExecutingError(ex.Message));
        }

        return new CommandResult.Success();
    }
}