using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.ParsingAbstractions.Arguments;
using FileManager.Presentation.Parsing.ParsingAbstractions.SubCommands;

namespace FileManager.Presentation.Parsing.CommandsParsing.File.SubCommands;

public class FileShowParserLink : SubCommandParserLinkBase
{
    private readonly ICommandArgumentParserLink<FileShowCommandBuilder> _argumentsParserLink;

    public FileShowParserLink(ICommandArgumentParserLink<FileShowCommandBuilder> argumentsParserLink)
    {
        _argumentsParserLink = argumentsParserLink;
    }

    public override SubCommandParseResult Parse(StringsIterator iterator)
    {
        if (iterator.Current == "show")
        {
            var fileShowCommandBuilder = new FileShowCommandBuilder();
            CommandArgumentParseResult result = _argumentsParserLink.Parse(iterator, fileShowCommandBuilder);

            return result.ThenSubCommand();
        }

        return CallNext(iterator);
    }
}