using FileManager.Core.Errors;

namespace FileManager.Core.Commands.CommandBuilders;

public abstract record CommandBuildResult
{
    private CommandBuildResult() { }

    public sealed record Success(ICommand Command) : CommandBuildResult;

    public sealed record Failure(IError Error) : CommandBuildResult;
}