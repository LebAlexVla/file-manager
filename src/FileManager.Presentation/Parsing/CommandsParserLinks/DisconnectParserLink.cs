using FileManager.Core.Commands.CommandBuilders;

namespace FileManager.Presentation.Parsing.CommandsParserLinks;

public class DisconnectParserLink : CommandParserLinkBase
{
    public override CommandParseResult Parse(StringsStream stream)
    {
        if (stream.Current == "disconnect")
        {
            var commandBuilder = new DisconnectCommandBuilder();

            return new CommandParseResult.Success(commandBuilder.Build());
        }

        return CallNext(stream);
    }
}