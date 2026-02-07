using FileManager.Core.Commands.CommandsAdditions.Writing;
using FileManager.Core.Errors;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.FlagsValuesParsing.FileShowModeParsing;

public abstract record FileShowModeParseResult
{
    private FileShowModeParseResult() { }

    public sealed record Success(IWriter Mode) : FileShowModeParseResult;

    public sealed record Failure(IError Error) : FileShowModeParseResult;
}