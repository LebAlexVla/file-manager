using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.ParsingAbstractions.Arguments;
using FileManager.Presentation.Parsing.ParsingAbstractions.SubCommands;

namespace FileManager.Presentation.Parsing.CommandsParsing.File.SubCommands;

public class FileDeleteParserLink : SubCommandParserLinkBase
{
    private readonly ICommandArgumentParserLink<FileDeleteCommandBuilder> _argumentsParserLink;

    public FileDeleteParserLink(ICommandArgumentParserLink<FileDeleteCommandBuilder> argumentsParserLink)
    {
        _argumentsParserLink = argumentsParserLink;
    }

    public override SubCommandParseResult Parse(StringsIterator iterator)
    {
        if (iterator.Current == "delete")
        {
            var fileDeleteCommandBuilder = new FileDeleteCommandBuilder();
            CommandArgumentParseResult result = _argumentsParserLink.Parse(iterator, fileDeleteCommandBuilder);

            return result.ThenSubCommand();
        }

        return CallNext(iterator);
    }
}