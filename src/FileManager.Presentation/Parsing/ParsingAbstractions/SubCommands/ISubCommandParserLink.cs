namespace FileManager.Presentation.Parsing.ParsingAbstractions.SubCommands;

public interface ISubCommandParserLink : ISubCommandParserService
{
    ISubCommandParserLink AddNext(ISubCommandParserLink link);
}