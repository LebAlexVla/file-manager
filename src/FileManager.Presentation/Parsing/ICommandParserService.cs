namespace FileManager.Presentation.Parsing;

public interface ICommandParserService
{
    CommandParseResult Parse(StringsIterator iterator);
}