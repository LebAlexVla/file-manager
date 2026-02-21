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

            ConnectModeParseResult result = _connectModeParserLink.Parse(iterator.MoveNext());
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