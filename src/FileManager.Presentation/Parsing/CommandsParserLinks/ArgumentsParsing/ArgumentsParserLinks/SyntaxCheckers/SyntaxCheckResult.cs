using FileManager.Core.Errors;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.ArgumentsParsing.ArgumentsParserLinks.SyntaxCheckers;

public abstract record SyntaxCheckResult
{
    private SyntaxCheckResult() { }

    public sealed record Success : SyntaxCheckResult;

    public sealed record Failure(IError Error) : SyntaxCheckResult;
}