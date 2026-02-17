using FileManager.Core.Commands.CommandsAdditions.ConnectModes;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.FlagsValuesParsing.ConnectModeParsing;

public abstract record ConnectModeParseResult
{
    private ConnectModeParseResult() { }

    public sealed record Success(IConnectMode Mode) : ConnectModeParseResult;

    public sealed record Failure(ParsingError Error) : ConnectModeParseResult;
}