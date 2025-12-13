namespace FileManager.Presentation.Parsing;

public interface ICommandParserLink : ICommandParserService
{
    ICommandParserLink AddNext(ICommandParserLink parserLink);
}