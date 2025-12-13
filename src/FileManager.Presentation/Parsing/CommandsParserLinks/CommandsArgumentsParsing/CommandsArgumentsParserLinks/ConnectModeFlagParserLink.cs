using FileManager.Core.Commands.CommandBuilders;
using FileManager.Core.Errors;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;
using FileManager.Presentation.Parsing.CommandsParserLinks.FlagsArgumentsParsing;
using FileManager.Presentation.Parsing.CommandsParserLinks.FlagsArgumentsParsing.FlagArgumentParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks;

public class ConnectModeFlagParserLink : CommandArgumentParserLinkBase<ConnectCommandBuilder>
{
    private readonly IFlagArgumentParserLink<ConnectCommandBuilder> _parameters;

    public ConnectModeFlagParserLink(IFlagArgumentParserLink<ConnectCommandBuilder> link)
    {
        _parameters = link;
    }

    public override CommandArgumentParseResult Parse(StringsStream stream, ConnectCommandBuilder commandBuilder)
    {
        if (stream.IsLast)
        {
            return new CommandArgumentParseResult.Success(commandBuilder);
        }

        stream.MoveNext();

        if (stream.Current == "-m")
        {
            return stream.IsLast
                ? new CommandArgumentParseResult.Failure(new ParsingError("Lonely flag"))
                : _parameters.Parse(stream.MoveNext(), commandBuilder).Then();
        }

        return CallNext(stream, commandBuilder);
    }
}