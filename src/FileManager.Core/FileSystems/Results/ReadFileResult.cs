using FileManager.Core.Errors;

namespace FileManager.Core.FileSystems.Results;

public abstract record ReadFileResult
{
    private ReadFileResult() { }

    public sealed record Success(string Content) : ReadFileResult;

    public sealed record Failure(IError Error) : ReadFileResult;
}