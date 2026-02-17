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

    public override CommandParseResult Parse(StringsStream stream)
    {
        if (stream.Current == "tree")
        {
            if (stream.IsLast)
            {
                return new CommandParseResult.Failure(
                    new ParsingError("Lonely tree command"));
            }

            return _subCommandParserLink.Parse(stream).Then();
        }

        return CallNext(stream);
    }
}