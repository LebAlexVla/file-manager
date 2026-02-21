namespace FileManager.Presentation.Parsing.CommandsParsing.Connect.ConnectMode;

public interface IConnectModeParserService
{
    ConnectModeParseResult Parse(string? rawConnectMode);
}