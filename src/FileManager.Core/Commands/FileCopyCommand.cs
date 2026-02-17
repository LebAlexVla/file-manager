using FileManager.Core.CommandsExecuting;
using FileManager.Core.Errors;

namespace FileManager.Core.Commands;

public class FileCopyCommand : ICommand
{
    private string _sourcePath;
    private string _destinationPath;

    public FileCopyCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public CommandResult Execute(IContext context)
    {
        if (context.FileSystem is null || context.CurrentDirectory is null)
        {
            return new CommandResult.Failure(new ExecutingError("Problems with file system or current directory"));
        }

        try
        {
            _sourcePath = context.FileSystem.UpdatePath(context.CurrentDirectory, _sourcePath);
            if (!context.FileSystem.FileExists(_sourcePath))
            {
                return new CommandResult.Failure(new ExecutingError("File not found"));
            }

            _destinationPath = context.FileSystem.UpdatePath(context.CurrentDirectory, _destinationPath);
            context.FileSystem.CopyFile(_sourcePath, _destinationPath);
        }
        catch (Exception ex)
        {
            return new CommandResult.Failure(new ExecutingError(ex.Message));
        }

        return new CommandResult.Success();
    }
}