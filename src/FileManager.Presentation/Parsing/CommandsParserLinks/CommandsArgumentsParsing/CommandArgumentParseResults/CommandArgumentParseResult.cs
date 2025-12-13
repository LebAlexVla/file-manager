using FileManager.Core.Commands.CommandBuilders;
using FileManager.Core.Errors;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;

public abstract record CommandArgumentParseResult
{
    private CommandArgumentParseResult() { }

    public sealed record Success(ICommandBuilder CommandBuilder) : CommandArgumentParseResult;

    public sealed record Failure(IError Error) : CommandArgumentParseResult;
}