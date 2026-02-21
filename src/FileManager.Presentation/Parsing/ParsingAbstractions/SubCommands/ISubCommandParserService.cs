namespace FileManager.Presentation.Parsing.ParsingAbstractions.SubCommands;

public interface ISubCommandParserService
{
    SubCommandParseResult Parse(StringsIterator iterator);
}