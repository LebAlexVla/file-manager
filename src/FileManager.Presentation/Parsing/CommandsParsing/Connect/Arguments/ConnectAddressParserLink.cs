using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.ParsingAbstractions.Arguments;

namespace FileManager.Presentation.Parsing.CommandsParsing.Connect.Arguments;

public class ConnectAddressParserLink : CommandArgumentParserLinkBase<ConnectCommandBuilder>
{
    public override CommandArgumentParseResult Parse(StringsIterator iterator, ConnectCommandBuilder commandBuilder)
    {
        if (iterator.IsLast)
        {
            return new CommandArgumentParseResult.Failure(new ParsingError("No connect address"));
        }

        commandBuilder.WithAddress(iterator.MoveNext());

        return CallNext(iterator, commandBuilder);
    }
}