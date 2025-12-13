namespace FileManager.Presentation.Parsing.CommandsParserLinks.SubCommandsParsing;

public interface ISubCommandParserLink : ISubCommandParserService
{
    ISubCommandParserLink AddNext(ISubCommandParserLink link);
}