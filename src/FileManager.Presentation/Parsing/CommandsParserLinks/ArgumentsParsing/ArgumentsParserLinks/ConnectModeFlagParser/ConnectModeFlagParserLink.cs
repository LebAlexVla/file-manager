using FileManager.Core.Commands.CommandBuilders;
using FileManager.Core.Errors;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.ArgumentsParsing.ArgumentsParserLinks.ConnectModeFlagParser;

public class ConnectModeFlagParserLink : ArgumentParserLinkBase<ConnectCommandBuilder>
{
    private readonly IArgumentParserLink<ConnectCommandBuilder> _parameters;

    public ConnectModeFlagParserLink(IArgumentParserLink<ConnectCommandBuilder> link)
    {
        _parameters = link;
    }

    public override ArgumentParseResult Parse(StringsStream stream, ConnectCommandBuilder commandBuilder)
    {
        if (stream.IsLast)
        {
            return new ArgumentParseResult.Success(commandBuilder);
        }

        stream.MoveNext();

        if (stream.Current == "-m")
        {
            return stream.IsLast
                ? new ArgumentParseResult.Failure(new ParsingError("Lonely flag"))
                : _parameters.Parse(stream, commandBuilder);
        }

        return CallNext(stream, commandBuilder);
    }
}