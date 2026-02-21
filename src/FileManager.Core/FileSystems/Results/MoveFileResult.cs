using FileManager.Core.Errors;

namespace FileManager.Core.FileSystems.Results;

public abstract record MoveFileResult
{
    private MoveFileResult() { }

    public sealed record Success : MoveFileResult;

    public sealed record Failure(IError Error) : MoveFileResult;
}