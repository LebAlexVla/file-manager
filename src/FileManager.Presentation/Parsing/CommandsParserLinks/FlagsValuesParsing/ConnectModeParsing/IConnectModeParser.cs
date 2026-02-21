namespace FileManager.Presentation.Parsing.CommandsParserLinks.FlagsValuesParsing.ConnectModeParsing;

public interface IConnectModeParser : IConnectModeParserService
{
    IConnectModeParser AddNext(IConnectModeParser parser);
}