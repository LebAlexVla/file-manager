using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing;

public interface ICommandArgumentParserService<T> where T : ICommandBuilder
{
    CommandArgumentParseResult Parse(StringsIterator iterator, T commandBuilder);
}