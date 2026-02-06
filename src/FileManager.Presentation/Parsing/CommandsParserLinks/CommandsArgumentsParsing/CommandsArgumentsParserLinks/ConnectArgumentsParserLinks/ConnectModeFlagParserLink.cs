using FileManager.Core.Commands.CommandBuilders;
using FileManager.Core.Errors;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.ConnectArgumentsParserLinks;

public class ConnectModeFlagParserLink : CommandArgumentParserLinkBase<ConnectCommandBuilder>
{
    public override CommandArgumentParseResult Parse(StringsStream stream, ConnectCommandBuilder commandBuilder)
    {
        if (stream.Current == "-m")
        {
            if (stream.IsLast)
            {
                return new CommandArgumentParseResult.Failure(new ParsingError("Lonely flag -m"));
            }

            return new CommandArgumentParseResult.Success(commandBuilder.WithMode(stream.MoveNext()));
        }

        return CallNext(stream, commandBuilder);
    }
}