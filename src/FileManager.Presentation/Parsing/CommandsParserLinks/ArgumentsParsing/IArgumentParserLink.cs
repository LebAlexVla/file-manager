using FileManager.Core.Commands.CommandBuilders;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.ArgumentsParsing;

public interface IArgumentParserLink<T> : IArgumentParserService<T> where T : ICommandBuilder
{
    IArgumentParserLink<T> AddNext(IArgumentParserLink<T> parserLink);
}