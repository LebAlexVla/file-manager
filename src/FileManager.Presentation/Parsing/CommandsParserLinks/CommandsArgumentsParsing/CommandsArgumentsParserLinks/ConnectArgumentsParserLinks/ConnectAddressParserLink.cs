using FileManager.Core.Commands.CommandBuilders;
using FileManager.Core.Errors;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.ConnectArgumentsParserLinks;

public class ConnectAddressParserLink : CommandArgumentParserLinkBase<ConnectCommandBuilder>
{
    public override CommandArgumentParseResult Parse(StringsStream stream, ConnectCommandBuilder commandBuilder)
    {
        if (!stream.IsLast)
        {
            return new CommandArgumentParseResult.Failure(new ParsingError("No connect path"));
        }

        stream.MoveNext();

        commandBuilder.WithAddress(stream.Current);

        return CallNext(stream, commandBuilder);
    }
}