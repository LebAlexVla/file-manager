using FileManager.Presentation.Parsing.CommandsParserLinks.SubCommandsParsing;
using FileManager.Presentation.Parsing.CommandsParserLinks.SubCommandsParsing.SubCommandParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks;

public class FileCommandsParserLink : CommandParserLinkBase
{
    private readonly ISubCommandParserLink _subCommandParserLink;

    public FileCommandsParserLink(ISubCommandParserLink subCommandParserLink)
    {
        _subCommandParserLink = subCommandParserLink;
    }

    public override CommandParseResult Parse(StringsIterator iterator)
    {
        if (iterator.Current == "file")
        {
            if (iterator.IsLast)
            {
                return new CommandParseResult.Failure(
                    new ParsingError("Lonely file command"));
            }

            iterator.MoveNext();

            return _subCommandParserLink.Parse(iterator).Then();
        }

        return CallNext(iterator);
    }
}