namespace FileManager.Presentation.Parsing.CommandsParserLinks.FlagsValuesParsing.FileShowModeParsing;

public interface IFileShowModeParserService
{
    FileShowModeParseResult Parse(string? rawMode);
}