using FileManager.Core.Commands.CommandBuilders;

namespace FileManager.Presentation.Parsing.ParsingAbstractions.Arguments;

public interface ICommandArgumentParserLink<T> : ICommandArgumentParserService<T> where T : ICommandBuilder
{
    ICommandArgumentParserLink<T> AddNext(ICommandArgumentParserLink<T> parserLink);
}