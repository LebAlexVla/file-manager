using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;
using FileManager.Presentation.Parsing.CommandsParserLinks.SubCommandsParsing.SubCommandParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.SubCommandsParsing.FileSubCommandsParsing;

public class FileMoveParserLink : SubCommandParserLinkBase
{
    private readonly ICommandArgumentParserLink<FileMoveCommandBuilder> _argumentsParserLink;

    public FileMoveParserLink(ICommandArgumentParserLink<FileMoveCommandBuilder> argumentsParserLink)
    {
        _argumentsParserLink = argumentsParserLink;
    }

    public override SubCommandParseResult Parse(StringsStream stream)
    {
        if (stream.Current == "move")
        {
            var fileMoveCommandBuilder = new FileMoveCommandBuilder();
            CommandArgumentParseResult result = _argumentsParserLink.Parse(stream, fileMoveCommandBuilder);

            return result.ThenSubCommand();
        }

        return CallNext(stream);
    }
}