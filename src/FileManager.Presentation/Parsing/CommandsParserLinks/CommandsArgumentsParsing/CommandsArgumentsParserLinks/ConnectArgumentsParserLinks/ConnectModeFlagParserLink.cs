using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;
using FileManager.Presentation.Parsing.CommandsParserLinks.FlagsValuesParsing.ConnectModeParsing;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.ConnectArgumentsParserLinks;

public class ConnectModeFlagParserLink : CommandArgumentParserLinkBase<ConnectCommandBuilder>
{
    private readonly IConnectModeParser _connectModeParser;

    public ConnectModeFlagParserLink(IConnectModeParser connectModeParser)
    {
        _connectModeParser = connectModeParser;
    }

    public override CommandArgumentParseResult Parse(StringsIterator iterator, ConnectCommandBuilder commandBuilder)
    {
        if (iterator.IsLast)
        {
            return new CommandArgumentParseResult.Success(commandBuilder);
        }

        if (iterator.MoveNext() == "-m")
        {
            if (iterator.IsLast)
            {
                return new CommandArgumentParseResult.Failure(new ParsingError("Lonely flag -m"));
            }

            ConnectModeParseResult result = _connectModeParser.Parse(iterator.MoveNext());
            if (result is ConnectModeParseResult.Success(var connectMode))
            {
                commandBuilder.WithMode(connectMode);
            }

            if (iterator.IsLast)
            {
                return new CommandArgumentParseResult.Success(commandBuilder);
            }

            if (result is ConnectModeParseResult.Failure(var error))
            {
                return new CommandArgumentParseResult.Failure(error);
            }
        }

        return CallNext(iterator, commandBuilder);
    }
}