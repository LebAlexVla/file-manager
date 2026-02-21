using FileManager.Core.CommandsExecuting;
using FileManager.Core.CommandsExecuting.State;
using FileManager.Core.Errors;
using FileManager.Core.FileSystems.Results;

namespace FileManager.Core.Commands;

public class FileMoveCommand : ICommand
{
    private string _sourcePath;
    private string _destinationPath;

    public FileMoveCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public CommandResult Execute(Context context)
    {
        if (context.State is not ConnectedState connectedState)
        {
            return new CommandResult.Failure(new ExecutingError("Not connected"));
        }

        UpdatePathResult updatePathResult = connectedState.FileSystem.UpdatePath(
            connectedState.CurrentDirectory, _sourcePath);
        switch (updatePathResult)
        {
            case UpdatePathResult.Failure(var error):
                return new CommandResult.Failure(error);
            case UpdatePathResult.Success(var path):
                _sourcePath = path;
                break;
        }

        updatePathResult = connectedState.FileSystem.UpdatePath(
            connectedState.CurrentDirectory, _destinationPath);
        switch (updatePathResult)
        {
            case UpdatePathResult.Failure(var updateError):
                return new CommandResult.Failure(updateError);
            case UpdatePathResult.Success(var path):
                _destinationPath = path;
                break;
        }

        MoveFileResult moveFileResult = connectedState.FileSystem.MoveFile(
            _sourcePath, _destinationPath);
        if (moveFileResult is MoveFileResult.Failure(var moveError))
        {
            return new CommandResult.Failure(moveError);
        }

        return new CommandResult.Success();
    }
}