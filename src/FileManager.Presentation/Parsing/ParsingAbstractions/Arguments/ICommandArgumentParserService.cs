using FileManager.Core.Commands.CommandBuilders;

namespace FileManager.Presentation.Parsing.ParsingAbstractions.Arguments;

public interface ICommandArgumentParserService<T> where T : ICommandBuilder
{
    CommandArgumentParseResult Parse(StringsIterator iterator, T commandBuilder);
}