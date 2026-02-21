using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;
using FileManager.Presentation.Parsing.CommandsParserLinks.SubCommandsParsing.SubCommandParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.SubCommandsParsing.FileSubCommandsParsing;

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