using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;
using FileManager.Presentation.Parsing.CommandsParserLinks.FlagsValuesParsing.ConnectModeParsing;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.ConnectArgumentsParserLinks;

public class ConnectModeFlagParserLink : CommandArgumentParserLinkBase<ConnectCommandBuilder>
{
    private readonly IConnectModeParserLink _connectModeParserLink;

    public ConnectModeFlagParserLink(IConnectModeParserLink connectModeParserLink)
    {
        _connectModeParserLink = connectModeParserLink;
    }

    public override CommandArgumentParseResult Parse(StringsStream stream, ConnectCommandBuilder commandBuilder)
    {
        if (stream.IsLast)
        {
            return new CommandArgumentParseResult.Success(commandBuilder);
        }

        if (stream.MoveNext() == "-m")
        {
            if (stream.IsLast)
            {
                return new CommandArgumentParseResult.Failure(new ParsingError("Lonely flag -m"));
            }

            ConnectModeParseResult result = _connectModeParserLink.Parse(stream.MoveNext());
            if (result is ConnectModeParseResult.Success(var connectMode))
            {
                commandBuilder.WithMode(connectMode);
            }

            if (stream.IsLast)
            {
                return new CommandArgumentParseResult.Success(commandBuilder);
            }

            if (result is ConnectModeParseResult.Failure(var error))
            {
                return new CommandArgumentParseResult.Failure(error);
            }
        }

        return CallNext(stream, commandBuilder);
    }
}