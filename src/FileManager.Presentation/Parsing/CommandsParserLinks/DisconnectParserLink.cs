using FileManager.Core.Commands.CommandBuilders;

namespace FileManager.Presentation.Parsing.CommandsParserLinks;

public class DisconnectParserLink : CommandParserLinkBase
{
    public override CommandParseResult Parse(StringsIterator iterator)
    {
        if (iterator.Current == "disconnect")
        {
            var commandBuilder = new DisconnectCommandBuilder();

            if (iterator.IsLast)
            {
                return new CommandParseResult.Success(commandBuilder.Build());
            }
        }

        return CallNext(iterator);
    }
}