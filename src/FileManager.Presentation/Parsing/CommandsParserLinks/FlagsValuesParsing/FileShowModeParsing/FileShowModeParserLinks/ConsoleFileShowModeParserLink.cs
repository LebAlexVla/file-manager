using FileManager.Core.Commands.CommandsAdditions.Writing;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.FlagsValuesParsing.FileShowModeParsing.FileShowModeParserLinks;

public class ConsoleFileShowModeParserLink : FileShowModeParserLinkBase
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