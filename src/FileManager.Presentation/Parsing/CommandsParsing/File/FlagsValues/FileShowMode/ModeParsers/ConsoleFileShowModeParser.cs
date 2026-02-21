using FileManager.Core.Commands.CommandsAdditions.Writing;

namespace FileManager.Presentation.Parsing.CommandsParsing.File.FlagsValues.FileShowMode.ModeParsers;

public class ConsoleFileShowModeParser : FileShowModeParserBase
{
    public override FileShowModeParseResult Parse(string? rawMode)
    {
        if (rawMode is null or "console")
        {
            return new FileShowModeParseResult.Success(new ConsoleWriter());
        }

        return CallNext(rawMode);
    }
}