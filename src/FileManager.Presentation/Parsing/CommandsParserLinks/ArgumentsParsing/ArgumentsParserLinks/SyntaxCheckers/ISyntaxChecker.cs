namespace FileManager.Presentation.Parsing.CommandsParserLinks.ArgumentsParsing.ArgumentsParserLinks.SyntaxCheckers;

public interface ISyntaxChecker
{
    SyntaxCheckResult Check(string text);
}