using FileManager.Core.Commands.CommandBuilders;
using FileManager.Core.Errors;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.TreeSubcommandsArgumentsParserLinks.TreeGotoArgumentsParserLinks;

public class TreeGotoPathParserLink : CommandArgumentParserLinkBase<TreeGotoCommandBuilder>
{
    public override CommandArgumentParseResult Parse(StringsStream stream, TreeGotoCommandBuilder commandBuilder)
    {
        if (stream.IsLast)
        {
            return new CommandArgumentParseResult.Failure(new ParsingError("Path not specified for command tree goto"));
        }

        commandBuilder.WithPath(stream.MoveNext());

        if (stream.IsLast)
        {
            return new CommandArgumentParseResult.Success(commandBuilder);
        }

        return CallNext(stream, commandBuilder);
    }
}