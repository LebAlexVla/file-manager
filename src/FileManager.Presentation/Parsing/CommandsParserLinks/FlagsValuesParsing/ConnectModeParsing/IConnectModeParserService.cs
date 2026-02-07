namespace FileManager.Presentation.Parsing.CommandsParserLinks.FlagsValuesParsing.ConnectModeParsing;

public interface IConnectModeParserService
{
    ConnectModeParseResult Parse(string? rawConnectMode);
}