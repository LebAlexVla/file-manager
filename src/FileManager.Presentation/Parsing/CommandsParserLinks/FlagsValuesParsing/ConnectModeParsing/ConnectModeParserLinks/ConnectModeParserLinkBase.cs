using FileManager.Core.Errors;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.FlagsValuesParsing.ConnectModeParsing.ConnectModeParserLinks;

public abstract class ConnectModeParserLinkBase : IConnectModeParserLink
{
    private IConnectModeParserLink? _next;

    public abstract ConnectModeParseResult Parse(string? rawConnectMode);

    public IConnectModeParserLink AddNext(IConnectModeParserLink parserLink)
    {
        if (_next == null)
        {
            _next = parserLink;
        }
        else
        {
            _next = _next.AddNext(parserLink);
        }

        return this;
    }

    protected ConnectModeParseResult CallNext(string rawMode)
    {
        return _next?.Parse(rawMode)
               ?? new ConnectModeParseResult.Failure(
                   new ParsingError("No connect mode parser link found"));
    }
}