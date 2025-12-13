using FileManager.Core.Errors;
using FileManager.Presentation.Parsing.CommandsParserLinks.SubCommandsParsing.SubCommandParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.SubCommandsParsing;

public abstract class SubCommandParserLinkBase : ISubCommandParserLink
{
    private ISubCommandParserLink? _next;

    public abstract SubCommandParseResult Parse(StringsStream stream);

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

    protected SubCommandParseResult CallNext(StringsStream stream)
    {
        return _next?.Parse(stream)
               ?? new SubCommandParseResult.Failure(new ParsingError("Invalid subcommand parser link"));
    }
}