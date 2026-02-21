using FileManager.Presentation.Parsing.ParsingAbstractions.Commands;
using FileManager.Presentation.Parsing.ParsingAbstractions.SubCommands;

namespace FileManager.Presentation.Parsing.CommandsParsing.File;

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