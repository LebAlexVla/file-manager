using FileManager.Core.Errors;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.FlagsValuesParsing.FileShowModeParsing.FileShowModeParserLinks;

public abstract class FileShowModeParserLinkBase : IFileShowModeParserLink
{
    private IFileShowModeParserLink? _next;

    public abstract FileShowModeParseResult Parse(string? rawMode);

    public IFileShowModeParserLink AddNext(IFileShowModeParserLink parserLink)
    {
        if (_next == null)
        {
            _next = parserLink;
        }
        else
        {
            _next = _next.AddNext(parserLink);
        }

        return this;
    }

    protected FileShowModeParseResult CallNext(string rawMode)
    {
        return _next?.Parse(rawMode)
               ?? new FileShowModeParseResult.Failure(
                   new ParsingError("No file show mode parser link found"));
    }
}