namespace FileManager.Presentation.Parsing.CommandsParserLinks;

public abstract class CommandParserLinkBase : ICommandParserLink
{
    private ICommandParserLink? _next;

    public abstract CommandParseResult Parse(StringsStream stream);

    public ICommandParserLink AddNext(ICommandParserLink parserLink)
    {
        if (_next is null)
        {
            _next = parserLink;
        }
        else
        {
            _next.AddNext(parserLink);
        }

        return this;
    }

    protected CommandParseResult CallNext(StringsStream stream)
    {
        return _next?.Parse(stream) ?? new CommandParseResult.Failure(new ParsingError("No parser link found"));
    }
}