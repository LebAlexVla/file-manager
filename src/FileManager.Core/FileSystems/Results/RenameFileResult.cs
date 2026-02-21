using FileManager.Core.Errors;

namespace FileManager.Core.FileSystems.Results;

public abstract record RenameFileResult
{
    private RenameFileResult() { }

    public sealed record Success : RenameFileResult;

    public sealed record Failure(IError Error) : RenameFileResult;
}