using FileManager.Core.Commands.CommandsAdditions.Writing;
using FileManager.Core.CommandsExecuting;
using FileManager.Core.CommandsExecuting.State;
using FileManager.Core.Errors;
using FileManager.Core.FileSystems.Results;

namespace FileManager.Core.Commands;

public class FileShowCommand : ICommand
{
    private readonly IWriter _writer;
    private string _path;

    public FileShowCommand(IWriter writer, string path)
    {
        _writer = writer;
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

        if (!connectedState.FileSystem.FileExists(_path))
        {
            return new CommandResult.Failure(new ExecutingError("File not found"));
        }

        ReadFileResult readFileResult = connectedState.FileSystem.ReadFile(_path);
        switch (readFileResult)
        {
            case ReadFileResult.Failure(var readError):
                return new CommandResult.Failure(readError);
            case ReadFileResult.Success(var content):
                _writer.Write(content);
                break;
        }

        return new CommandResult.Success();
    }
}