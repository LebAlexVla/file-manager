namespace FileManager.Presentation.Parsing.CommandsParserLinks.FlagsValuesParsing.FileShowModeParsing;

public interface IFileShowModeParserLink : IFileShowModeParserService
{
    IFileShowModeParserLink AddNext(IFileShowModeParserLink parserLink);
}