using FileManager.Presentation.Parsing.CommandsParserLinks.SubCommandsParsing.SubCommandParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.SubCommandsParsing;

public interface ISubCommandParserService
{
    SubCommandParseResult Parse(StringsStream stream);
}