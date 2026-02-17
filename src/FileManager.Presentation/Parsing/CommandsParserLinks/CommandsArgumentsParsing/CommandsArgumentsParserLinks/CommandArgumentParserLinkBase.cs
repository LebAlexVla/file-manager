using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks;

public abstract class CommandArgumentParserLinkBase<T> : ICommandArgumentParserLink<T> where T : ICommandBuilder
{
    private ICommandArgumentParserLink<T>? _next;

    public abstract CommandArgumentParseResult Parse(StringsStream stream, T commandBuilder);

    public ICommandArgumentParserLink<T> AddNext(ICommandArgumentParserLink<T> parserLink)
    {
        if (_next == null)
        {
            _next = parserLink;
        }
        else
        {
            _next.AddNext(parserLink);
        }

        return this;
    }

    protected CommandArgumentParseResult CallNext(StringsStream stream, T commandBuilder)
    {
        return _next?.Parse(stream, commandBuilder)
               ?? new CommandArgumentParseResult.Failure(new ParsingError("Invalid argument parser link"));
    }
}