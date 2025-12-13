using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.CommandsParserLinks.FlagsArgumentsParsing.FlagArgumentParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.FlagsArgumentsParsing;

public interface IFlagArgumentParserService<T> where T : ICommandBuilder
{
    FlagArgumentParseResult Parse(string text, T commandBuilder);
}