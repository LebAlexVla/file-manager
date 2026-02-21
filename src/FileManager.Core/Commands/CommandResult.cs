using FileManager.Core.Errors;

namespace FileManager.Core.Commands;

public abstract record CommandResult
{
    private CommandResult() { }

    public sealed record Success : CommandResult;

    public sealed record Failure(IError Error) : CommandResult;
}