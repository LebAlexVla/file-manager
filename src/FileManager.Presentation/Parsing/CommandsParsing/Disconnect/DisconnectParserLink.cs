using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.ParsingAbstractions.Commands;

namespace FileManager.Presentation.Parsing.CommandsParsing.Disconnect;

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