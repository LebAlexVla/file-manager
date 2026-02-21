using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks;

public class ConnectParserLink : CommandParserLinkBase
{
    private readonly ICommandArgumentParserLink<ConnectCommandBuilder> _argumentsParserLink;

    public ConnectParserLink(ICommandArgumentParserLink<ConnectCommandBuilder> commandArgumentParserLink)
    {
        _argumentsParserLink = commandArgumentParserLink;
    }

    public override CommandParseResult Parse(StringsIterator iterator)
    {
        if (iterator.Current == "connect")
        {
            var connectCommandBuilder = new ConnectCommandBuilder();
            CommandArgumentParseResult result = _argumentsParserLink.Parse(iterator, connectCommandBuilder);

            return result.ThenCommand();
        }

        return CallNext(iterator);
    }
}