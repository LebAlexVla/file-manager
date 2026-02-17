using FileManager.Core.Commands;

namespace FileManager.Presentation.Parsing;

public abstract record CommandParseResult
{
    private CommandParseResult() { }

    public sealed record Success(ICommand Command) : CommandParseResult;

    public sealed record Failure(ParsingError Error) : CommandParseResult;
}