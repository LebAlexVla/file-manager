using FileManager.Core.Commands.CommandBuilders;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.FlagsArgumentsParsing;

public interface IFlagArgumentParserLink<T> : IFlagArgumentParserService<T> where T : ICommandBuilder
{
    IFlagArgumentParserLink<T> AddNext(IFlagArgumentParserLink<T> link);
}