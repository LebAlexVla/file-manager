using FileManager.Core.Commands.CommandsAdditions.ConnectModes;
using FileManager.Core.Errors;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.FlagsValuesParsing.ConnectModeParsing;

public abstract record ConnectModeParseResult
{
    private ConnectModeParseResult() { }

    public sealed record Success(IConnectMode Mode) : ConnectModeParseResult;

    public sealed record Failure(IError Error) : ConnectModeParseResult;
}