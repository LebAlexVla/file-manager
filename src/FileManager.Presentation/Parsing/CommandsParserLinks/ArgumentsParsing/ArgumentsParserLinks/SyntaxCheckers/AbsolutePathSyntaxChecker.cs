using FileManager.Core.Errors;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.ArgumentsParsing.ArgumentsParserLinks.SyntaxCheckers;

public class AbsolutePathSyntaxChecker : ISyntaxChecker
{
    public SyntaxCheckResult Check(string text)
    {
        return text.StartsWith('/')
            ? new SyntaxCheckResult.Success()
            : new SyntaxCheckResult.Failure(new ParsingError("Invalid absolute path"));
    }
}