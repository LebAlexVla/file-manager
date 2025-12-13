using FileManager.Core.Commands.CommandBuilders;
using FileManager.Core.Errors;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.ArgumentsParserLinks;

public class ConnectAddressParserLink : CommandArgumentParserLinkBase<ConnectCommandBuilder>
{
    public override CommandArgumentParseResult Parse(StringsStream stream, ConnectCommandBuilder commandBuilder)
    {
        if (stream.IsLast)
        {
            return new CommandArgumentParseResult.Failure(new ParsingError("No connect path"));
        }

        stream.MoveNext();

        commandBuilder.WithAddress(stream.Current);

        return stream.IsLast
                ? new CommandArgumentParseResult.Success(commandBuilder)
                : CallNext(stream, commandBuilder);
    }
}