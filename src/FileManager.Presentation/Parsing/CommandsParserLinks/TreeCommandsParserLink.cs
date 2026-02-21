using FileManager.Presentation.Parsing.CommandsParserLinks.SubCommandsParsing;
using FileManager.Presentation.Parsing.CommandsParserLinks.SubCommandsParsing.SubCommandParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks;

public class TreeCommandsParserLink : CommandParserLinkBase
{
    private readonly ISubCommandParserLink _subCommandParserLink;

    public TreeCommandsParserLink(ISubCommandParserLink subCommandParserLink)
    {
        _subCommandParserLink = subCommandParserLink;
    }

    public override CommandParseResult Parse(StringsIterator iterator)
    {
        if (iterator.Current == "tree")
        {
            if (iterator.IsLast)
            {
                return new CommandParseResult.Failure(
                    new ParsingError("Lonely tree command"));
            }

            return _subCommandParserLink.Parse(iterator).Then();
        }

        return CallNext(iterator);
    }
}