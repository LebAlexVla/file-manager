using FileManager.Core.CommandsExecuting;
using FileManager.Core.CommandsExecuting.State;
using FileManager.Core.Errors;
using FileManager.Core.FileSystems.Results;

namespace FileManager.Core.Commands;

public class FileRenameCommand : ICommand
{
    private readonly string _name;
    private string _path;

    public FileRenameCommand(string path, string name)
    {
        _path = path;
        _name = name;
    }

    public CommandResult Execute(Context context)
    {
        if (context.State is not ConnectedState connectedState)
        {
            return new CommandResult.Failure(new ExecutingError("Not connected"));
        }

        UpdatePathResult updatePathResult = connectedState.FileSystem.UpdatePath(
            connectedState.CurrentDirectory, _path);
        switch (updatePathResult)
        {
            case UpdatePathResult.Failure(var updateError):
                return new CommandResult.Failure(updateError);
            case UpdatePathResult.Success(var path):
                _path = path;
                break;
        }

        RenameFileResult renameFileResult = connectedState.FileSystem.RenameFile(_path, _name);
        if (renameFileResult is RenameFileResult.Failure(var renameError))
        {
            return new CommandResult.Failure(renameError);
        }

        return new CommandResult.Success();
    }
}