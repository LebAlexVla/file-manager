using FileManager.Core.Commands;
using FileManager.Core.Errors;

namespace FileManager.Presentation.Parsing;

public abstract record CommandParseResult
{
    private CommandParseResult() { }

    public sealed record Success(ICommand Command) : CommandParseResult;

    public sealed record Failure(IError Error) : CommandParseResult;
}