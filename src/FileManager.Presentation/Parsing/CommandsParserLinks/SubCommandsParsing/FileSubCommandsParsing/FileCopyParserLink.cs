using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;
using FileManager.Presentation.Parsing.CommandsParserLinks.SubCommandsParsing.SubCommandParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.SubCommandsParsing.FileSubCommandsParsing;

public class FileCopyParserLink : SubCommandParserLinkBase
{
    private readonly ICommandArgumentParserLink<FileCopyCommandBuilder> _argumentsParserLink;

    public FileCopyParserLink(ICommandArgumentParserLink<FileCopyCommandBuilder> argumentsParserLink)
    {
        _argumentsParserLink = argumentsParserLink;
    }

    public override SubCommandParseResult Parse(StringsStream stream)
    {
        if (stream.Current == "copy")
        {
            var fileCopyCommandBuilder = new FileCopyCommandBuilder();
            CommandArgumentParseResult result = _argumentsParserLink.Parse(stream, fileCopyCommandBuilder);

            return result.ThenSubCommand();
        }

        return CallNext(stream);
    }
}