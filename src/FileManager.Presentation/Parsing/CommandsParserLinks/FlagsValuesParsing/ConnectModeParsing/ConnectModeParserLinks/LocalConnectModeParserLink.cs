using FileManager.Core.Commands.CommandsAdditions.ConnectModes;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.FlagsValuesParsing.ConnectModeParsing.ConnectModeParserLinks;

public class LocalConnectModeParserLink : ConnectModeParserLinkBase
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