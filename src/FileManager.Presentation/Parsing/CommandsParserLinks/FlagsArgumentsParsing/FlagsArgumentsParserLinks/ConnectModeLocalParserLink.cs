using FileManager.Core.Commands.CommandBuilders;
using FileManager.Core.Commands.CommandsAdditions.ConnectModes;
using FileManager.Presentation.Parsing.CommandsParserLinks.FlagsArgumentsParsing.FlagArgumentParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.FlagsArgumentsParsing.FlagsArgumentsParserLinks;

public class ConnectModeLocalParserLink : FlagArgumentParserLinkBase<ConnectCommandBuilder>
{
    private readonly LocalConnectMode _connectMode = new LocalConnectMode();

    public override FlagArgumentParseResult Parse(string text, ConnectCommandBuilder commandBuilder)
    {
        if (text == "local")
        {
            commandBuilder.WithMode(_connectMode);

            return new FlagArgumentParseResult.Success(commandBuilder);
        }

        return CallNext(text, commandBuilder);
    }
}