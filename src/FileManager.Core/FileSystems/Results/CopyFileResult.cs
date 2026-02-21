using FileManager.Core.Errors;

namespace FileManager.Core.FileSystems.Results;

public abstract record CopyFileResult
{
    private CopyFileResult() { }

    public sealed record Success : CopyFileResult;

    public sealed record Failure(IError Error) : CopyFileResult;
}