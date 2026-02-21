namespace FileManager.Presentation.Parsing.CommandsParserLinks;

public abstract class CommandParserLinkBase : ICommandParserLink
{
    private ICommandParserLink? _next;

    public abstract CommandParseResult Parse(StringsIterator iterator);

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

    protected CommandParseResult CallNext(StringsIterator iterator)
    {
        return _next?.Parse(iterator) ?? new CommandParseResult.Failure(new ParsingError("No parser link found"));
    }
}