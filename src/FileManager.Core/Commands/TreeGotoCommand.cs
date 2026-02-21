using FileManager.Core.CommandsExecuting;
using FileManager.Core.CommandsExecuting.State;
using FileManager.Core.Errors;
using FileManager.Core.FileSystems.Results;

namespace FileManager.Core.Commands;

public class TreeGotoCommand : ICommand
{
    private string _path;

    public TreeGotoCommand(string path)
    {
        _path = path;
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

        if (!connectedState.FileSystem.DirectoryExists(_path))
        {
            return new CommandResult.Failure(new ExecutingError("Directory does not exist"));
        }

        connectedState.CurrentDirectory = _path;

        return new CommandResult.Success();
    }
}