using FileManager.Presentation.Parsing.ParsingAbstractions.Commands;

namespace FileManager.Presentation.Parsing;

public interface IParserFactory
{
    ICommandParserLink Create();
}