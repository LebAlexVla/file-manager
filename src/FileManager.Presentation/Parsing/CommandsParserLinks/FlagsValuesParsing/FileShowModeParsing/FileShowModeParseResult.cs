using FileManager.Core.Commands.CommandsAdditions.Writing;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.FlagsValuesParsing.FileShowModeParsing;

public abstract record FileShowModeParseResult
{
    private FileShowModeParseResult() { }

    public sealed record Success(IWriter Mode) : FileShowModeParseResult;

    public sealed record Failure(ParsingError Error) : FileShowModeParseResult;
}