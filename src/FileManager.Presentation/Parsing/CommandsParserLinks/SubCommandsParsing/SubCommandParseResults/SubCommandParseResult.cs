using FileManager.Core.Commands.CommandBuilders;
using FileManager.Core.Errors;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.SubCommandsParsing.SubCommandParseResults;

public abstract record SubCommandParseResult
{
    private SubCommandParseResult() { }

    public sealed record Success(ICommandBuilder CommandBuilder) : SubCommandParseResult;

    public sealed record Failure(IError Error) : SubCommandParseResult;
}