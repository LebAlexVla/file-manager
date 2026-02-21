using FileManager.Presentation.Parsing.ParsingAbstractions.Commands;

namespace FileManager.Presentation.Parsing.CommandsParsersFactories;

public interface ICommandParserFactory
{
    ICommandParserLink Create();
}