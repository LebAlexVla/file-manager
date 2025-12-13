using FileManager.Core.Commands.CommandBuilders;
using FileManager.Core.Errors;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.ArgumentsParsing.ArgumentsParserLinks;

public abstract class ArgumentParserLinkBase<T> : IArgumentParserLink<T> where T : ICommandBuilder
{
    private IArgumentParserLink<T>? _next;

    public abstract ArgumentParseResult Parse(StringsStream stream, T commandBuilder);

    public IArgumentParserLink<T> AddNext(IArgumentParserLink<T> parserLink)
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

    protected ArgumentParseResult CallNext(StringsStream stream, T commandBuilder)
    {
        return _next?.Parse(stream, commandBuilder)
               ?? new ArgumentParseResult.Failure(new ParsingError("Invalid argument parser link"));
    }
}