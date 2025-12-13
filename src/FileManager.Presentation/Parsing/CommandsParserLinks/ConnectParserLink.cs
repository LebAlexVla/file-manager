using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.CommandsParserLinks.ArgumentsParsing;

namespace FileManager.Presentation.Parsing.CommandsParserLinks;

public class ConnectParserLink : CommandParserLinkBase
{
    private readonly IArgumentParserLink<ConnectCommandBuilder> _argumentParserLink;

    public ConnectParserLink(IArgumentParserLink<ConnectCommandBuilder> argumentParserLink)
    {
        _argumentParserLink = argumentParserLink;
    }

    public override CommandParseResult Parse(StringsStream stream)
    {
        if (stream.Current == "connect")
        {
            var connectCommandBuilder = new ConnectCommandBuilder();
            ArgumentParseResult result = _argumentParserLink.Parse(stream, connectCommandBuilder);

            return result.Then();
        }

        return CallNext(stream);
    }
}