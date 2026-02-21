namespace FileManager.Presentation.Parsing.CommandsParsing.File.FlagsValues.FileShowMode;

public interface IFileShowModeParserService
{
    FileShowModeParseResult Parse(string? rawMode);
}