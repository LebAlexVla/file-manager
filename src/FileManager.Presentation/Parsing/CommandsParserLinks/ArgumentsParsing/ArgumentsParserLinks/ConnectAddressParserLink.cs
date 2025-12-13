using FileManager.Core.Commands.CommandBuilders;
using FileManager.Core.Errors;
using FileManager.Presentation.Parsing.CommandsParserLinks.ArgumentsParsing.ArgumentsParserLinks.SyntaxCheckers;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.ArgumentsParsing.ArgumentsParserLinks;

public class ConnectAddressParserLink : ArgumentParserLinkBase<ConnectCommandBuilder>
{
    private readonly ISyntaxChecker _checker;

    public ConnectAddressParserLink(ISyntaxChecker checker)
    {
        _checker = checker;
    }

    public override ArgumentParseResult Parse(StringsStream stream, ConnectCommandBuilder commandBuilder)
    {
        if (stream.IsLast)
        {
            return new ArgumentParseResult.Failure(new ParsingError("No connect path"));
        }

        stream.MoveNext();

        if (_checker.Check(stream.Current) is SyntaxCheckResult.Failure(var error))
        {
            return new ArgumentParseResult.Failure(error);
        }

        commandBuilder.WithAddress(stream.Current);

        return stream.IsLast
                ? new ArgumentParseResult.Success(commandBuilder)
                : CallNext(stream, commandBuilder);
    }
}