namespace FileManager.Presentation.Parsing.CommandsParserLinks.FlagsValuesParsing.ConnectModeParsing;

public interface IConnectModeParserLink : IConnectModeParserService
{
    IConnectModeParserLink AddNext(IConnectModeParserLink parserLink);
}