namespace FileManager.Presentation.Parsing.CommandsParsing.Connect.ConnectMode;

public interface IConnectModeParser : IConnectModeParserService
{
    IConnectModeParser AddNext(IConnectModeParser parser);
}