using FileManager.Core.Commands.CommandBuilders;

namespace FileManager.Presentation.Parsing.ParsingAbstractions.SubCommands;

public abstract record SubCommandParseResult
{
    private SubCommandParseResult() { }

    public sealed record Success(ICommandBuilder CommandBuilder) : SubCommandParseResult;

    public sealed record Failure(ParsingError Error) : SubCommandParseResult;
}