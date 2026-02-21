using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.ParsingAbstractions.Arguments;
using FileManager.Presentation.Parsing.ParsingAbstractions.SubCommands;

namespace FileManager.Presentation.Parsing.CommandsParsing.File.SubCommands;

public class FileMoveParserLink : SubCommandParserLinkBase
{
    private readonly ICommandArgumentParserLink<FileMoveCommandBuilder> _argumentsParserLink;

    public FileMoveParserLink(ICommandArgumentParserLink<FileMoveCommandBuilder> argumentsParserLink)
    {
        _argumentsParserLink = argumentsParserLink;
    }

    public override SubCommandParseResult Parse(StringsIterator iterator)
    {
        if (iterator.Current == "move")
        {
            var fileMoveCommandBuilder = new FileMoveCommandBuilder();
            CommandArgumentParseResult result = _argumentsParserLink.Parse(iterator, fileMoveCommandBuilder);

            return result.ThenSubCommand();
        }

        return CallNext(iterator);
    }
}