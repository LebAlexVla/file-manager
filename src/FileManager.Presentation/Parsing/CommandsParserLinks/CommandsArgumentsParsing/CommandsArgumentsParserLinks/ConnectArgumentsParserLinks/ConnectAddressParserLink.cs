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
            return new CommandArgumentParseResult.Failure(new ParsingError("No connect address"));
        }

        commandBuilder.WithAddress(stream.MoveNext());

        if (stream.IsLast)
        {
            return new CommandArgumentParseResult.Success(commandBuilder);
        }

        stream.MoveNext();

        return CallNext(stream, commandBuilder);
    }
}