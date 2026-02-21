using FileManager.Core.Commands.CommandsAdditions.ConnectModes;

namespace FileManager.Presentation.Parsing.CommandsParsing.Connect.ConnectMode.ModeParsers;

public class LocalConnectModeParser : ConnectModeParserBase
{
    public override ConnectModeParseResult Parse(string? rawConnectMode)
    {
        if (rawConnectMode == "local")
        {
            return new ConnectModeParseResult.Success(new LocalConnectMode());
        }

        return CallNext(rawConnectMode);
    }
}