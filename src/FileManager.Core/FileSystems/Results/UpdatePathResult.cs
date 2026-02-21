using FileManager.Core.Errors;

namespace FileManager.Core.FileSystems.Results;

public abstract record UpdatePathResult
{
    private UpdatePathResult() { }

    public sealed record Success(string NewPath) : UpdatePathResult;

    public sealed record Failure(IError Error) : UpdatePathResult;
}