using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;
using FileManager.Presentation.Parsing.CommandsParserLinks.SubCommandsParsing.SubCommandParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.SubCommandsParsing.FileSubCommandsParsing;

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