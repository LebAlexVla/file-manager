using FileManager.Core.Commands.CommandBuilders;

namespace FileManager.Presentation.Parsing.ParsingAbstractions.Arguments;

public abstract record CommandArgumentParseResult
{
    private CommandArgumentParseResult() { }

    public sealed record Success(ICommandBuilder CommandBuilder) : CommandArgumentParseResult;

    public sealed record Failure(ParsingError Error) : CommandArgumentParseResult;
}