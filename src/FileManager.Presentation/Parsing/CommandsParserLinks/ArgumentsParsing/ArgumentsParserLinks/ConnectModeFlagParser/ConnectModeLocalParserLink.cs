using FileManager.Core.Commands.CommandBuilders;
using FileManager.Core.Commands.CommandsAdditions.ConnectModes;
using FileManager.Core.Errors;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.ArgumentsParsing.ArgumentsParserLinks.ConnectModeFlagParser;

public class ConnectModeLocalParserLink : ArgumentParserLinkBase<ConnectCommandBuilder>
{
    private readonly LocalConnectMode _connectMode = new LocalConnectMode();

    public override ArgumentParseResult Parse(StringsStream stream, ConnectCommandBuilder commandBuilder)
    {
        if (stream.IsLast)
        {
            return new ArgumentParseResult.Failure(new ParsingError("No parameter for -m flag"));
        }

        stream.MoveNext();

        if (stream.Current == "local")
        {
            commandBuilder.WithMode(_connectMode);
        }

        return CallNext(stream, commandBuilder);
    }
}