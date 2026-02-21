namespace FileManager.Presentation.Parsing.CommandsParsing.File.FlagsValues.FileShowMode;

public interface IFileShowModeParser : IFileShowModeParserService
{
    IFileShowModeParser AddNext(IFileShowModeParser parser);
}