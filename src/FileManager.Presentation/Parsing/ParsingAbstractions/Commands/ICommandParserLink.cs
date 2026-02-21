namespace FileManager.Presentation.Parsing.ParsingAbstractions.Commands;

public interface ICommandParserLink : ICommandParserService
{
    ICommandParserLink AddNext(ICommandParserLink parserLink);
}