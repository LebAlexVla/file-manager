using FileManager.Core.Commands.CommandBuilders;
using FileManager.Core.Errors;
using FileManager.Presentation.Parsing.CommandsParserLinks.FlagsArgumentsParsing.FlagArgumentParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.FlagsArgumentsParsing.FlagsArgumentsParserLinks;

public abstract class FlagArgumentParserLinkBase<T> : IFlagArgumentParserLink<T> where T : ICommandBuilder
{
    private IFlagArgumentParserLink<T>? _next;

    public abstract FlagArgumentParseResult Parse(string text, T commandBuilder);

    public IFlagArgumentParserLink<T> AddNext(IFlagArgumentParserLink<T> link)
    {
        if (_next == null)
        {
            _next = link;
        }
        else
        {
            _next.AddNext(link);
        }

        return this;
    }

    protected FlagArgumentParseResult CallNext(string text, T commandBuilder)
    {
        return _next?.Parse(text, commandBuilder)
               ?? new FlagArgumentParseResult.Failure(new ParsingError("Invalid flag argument parser link"));
    }
}