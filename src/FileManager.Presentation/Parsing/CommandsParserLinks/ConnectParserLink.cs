using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks;

public class ConnectParserLink : CommandParserLinkBase
{
    private readonly ICommandArgumentParserLink<ConnectCommandBuilder> _commandArgumentParserLink;

    public ConnectParserLink(ICommandArgumentParserLink<ConnectCommandBuilder> commandArgumentParserLink)
    {
        _commandArgumentParserLink = commandArgumentParserLink;
    }

    public override CommandParseResult Parse(StringsStream stream)
    {
        if (stream.Current == "connect")
        {
            var connectCommandBuilder = new ConnectCommandBuilder();
            CommandArgumentParseResult result = _commandArgumentParserLink.Parse(stream, connectCommandBuilder);

            return result.Then();
        }

        return CallNext(stream);
    }
}