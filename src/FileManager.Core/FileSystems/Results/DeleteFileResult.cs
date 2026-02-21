using FileManager.Core.Errors;

namespace FileManager.Core.FileSystems.Results;

public abstract record DeleteFileResult
{
    private DeleteFileResult() { }

    public sealed record Success : DeleteFileResult;

    public sealed record Failure(IError Error) : DeleteFileResult;
}