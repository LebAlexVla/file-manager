using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.ParsingAbstractions.Arguments;
using FileManager.Presentation.Parsing.ParsingAbstractions.SubCommands;

namespace FileManager.Presentation.Parsing.CommandsParsing.File.SubCommands;

public class FileCopyParserLink : SubCommandParserLinkBase
{
    private readonly ICommandArgumentParserLink<FileCopyCommandBuilder> _argumentsParserLink;

    public FileCopyParserLink(ICommandArgumentParserLink<FileCopyCommandBuilder> argumentsParserLink)
    {
        _argumentsParserLink = argumentsParserLink;
    }

    public override SubCommandParseResult Parse(StringsIterator iterator)
    {
        if (iterator.Current == "copy")
        {
            var fileCopyCommandBuilder = new FileCopyCommandBuilder();
            CommandArgumentParseResult result = _argumentsParserLink.Parse(iterator, fileCopyCommandBuilder);

            return result.ThenSubCommand();
        }

        return CallNext(iterator);
    }
}