using FileManager.Core.Commands.CommandBuilders;
using FileManager.Core.Errors;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.ArgumentsParsing;

public abstract record ArgumentParseResult
{
    private ArgumentParseResult() { }

    public sealed record Success(ICommandBuilder CommandBuilder) : ArgumentParseResult;

    public sealed record Failure(IError Error) : ArgumentParseResult;
}