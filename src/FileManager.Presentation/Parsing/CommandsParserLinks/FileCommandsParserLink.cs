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

    public override CommandParseResult Parse(StringsStream stream)
    {
        if (stream.Current == "file")
        {
            if (stream.IsLast)
            {
                return new CommandParseResult.Failure(
                    new ParsingError("Lonely file command"));
            }

            stream.MoveNext();

            return _subCommandParserLink.Parse(stream).Then();
        }

        return CallNext(stream);
    }
}