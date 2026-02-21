namespace FileManager.Presentation.Parsing.CommandsParserLinks.FlagsValuesParsing.FileShowModeParsing;

public interface IFileShowModeParser : IFileShowModeParserService
{
    IFileShowModeParser AddNext(IFileShowModeParser parser);
}