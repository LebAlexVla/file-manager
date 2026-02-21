using FileManager.Core.CommandsExecuting;
using FileManager.Core.CommandsExecuting.State;
using FileManager.Core.Errors;
using FileManager.Core.FileSystems.Results;

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

        CopyFileResult copyFileResult = connectedState.FileSystem.CopyFile(
            _sourcePath, _destinationPath);
        if (copyFileResult is CopyFileResult.Failure(var copyError))
        {
            return new CommandResult.Failure(copyError);
        }

        return new CommandResult.Success();
    }
}