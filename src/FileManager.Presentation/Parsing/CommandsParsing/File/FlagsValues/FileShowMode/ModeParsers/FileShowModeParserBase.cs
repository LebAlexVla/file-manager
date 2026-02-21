namespace FileManager.Presentation.Parsing.CommandsParsing.File.FlagsValues.FileShowMode.ModeParsers;

public abstract class FileShowModeParserBase : IFileShowModeParser
{
    private IFileShowModeParser? _next;

    public abstract FileShowModeParseResult Parse(string? rawMode);

    public IFileShowModeParser AddNext(IFileShowModeParser parser)
    {
        if (_next == null)
        {
            _next = parser;
        }
        else
        {
            _next = _next.AddNext(parser);
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