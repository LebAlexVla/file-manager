namespace FileManager.Presentation.Parsing.ParsingAbstractions.SubCommands;

public abstract class SubCommandParserLinkBase : ISubCommandParserLink
{
    private ISubCommandParserLink? _next;

    public abstract SubCommandParseResult Parse(StringsIterator iterator);

    public ISubCommandParserLink AddNext(ISubCommandParserLink link)
    {
        if (_next is null)
        {
            _next = link;
        }
        else
        {
            _next.AddNext(link);
        }

        return this;
    }

    protected SubCommandParseResult CallNext(StringsIterator iterator)
    {
        return _next?.Parse(iterator)
               ?? new SubCommandParseResult.Failure(new ParsingError("Invalid subcommand parser link"));
    }
}