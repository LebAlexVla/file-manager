using FileManager.Presentation.Parsing.ParsingAbstractions.Commands;
using FileManager.Presentation.Parsing.ParsingAbstractions.SubCommands;

namespace FileManager.Presentation.Parsing.CommandsParsing.Tree;

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