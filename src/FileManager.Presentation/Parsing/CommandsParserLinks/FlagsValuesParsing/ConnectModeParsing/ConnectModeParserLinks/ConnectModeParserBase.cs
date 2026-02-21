namespace FileManager.Presentation.Parsing.CommandsParserLinks.FlagsValuesParsing.ConnectModeParsing.ConnectModeParserLinks;

public abstract class ConnectModeParserBase : IConnectModeParser
{
    private IConnectModeParser? _next;

    public abstract ConnectModeParseResult Parse(string? rawConnectMode);

    public IConnectModeParser AddNext(IConnectModeParser parser)
    {
        if (_next == null)
        {
            _next = parser;
        }
        else
        {
            _next = _next.AddNext(parser);
        }

        return this;
    }

    protected ConnectModeParseResult CallNext(string? rawMode)
    {
        return _next?.Parse(rawMode)
               ?? new ConnectModeParseResult.Failure(
                   new ParsingError("No such connect mode parser link found"));
    }
}