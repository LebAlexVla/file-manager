namespace FileManager.Presentation.Parsing.ParsingAbstractions.Commands;

public interface ICommandParserService
{
    CommandParseResult Parse(StringsIterator iterator);
}