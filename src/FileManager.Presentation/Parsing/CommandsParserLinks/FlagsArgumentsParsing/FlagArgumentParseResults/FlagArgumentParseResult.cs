using FileManager.Core.Commands.CommandBuilders;
using FileManager.Core.Errors;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.FlagsArgumentsParsing.FlagArgumentParseResults;

public abstract record FlagArgumentParseResult
{
    private FlagArgumentParseResult() { }

    public sealed record Success(ICommandBuilder CommandBuilder) : FlagArgumentParseResult;

    public sealed record Failure(IError Error) : FlagArgumentParseResult;
}