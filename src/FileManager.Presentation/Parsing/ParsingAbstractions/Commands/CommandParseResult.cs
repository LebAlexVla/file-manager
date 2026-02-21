using FileManager.Core.Commands;

namespace FileManager.Presentation.Parsing.ParsingAbstractions.Commands;

public abstract record CommandParseResult
{
    private CommandParseResult() { }

    public sealed record Success(ICommand Command) : CommandParseResult;

    public sealed record Failure(ParsingError Error) : CommandParseResult;
}