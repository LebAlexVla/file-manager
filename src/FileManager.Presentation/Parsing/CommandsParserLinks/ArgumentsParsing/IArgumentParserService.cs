using FileManager.Core.Commands.CommandBuilders;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.ArgumentsParsing;

public interface IArgumentParserService<T> where T : ICommandBuilder
{
    ArgumentParseResult Parse(StringsStream stream, T commandBuilder);
}