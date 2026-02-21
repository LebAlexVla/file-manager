using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.TreeSubcommandsArgumentsParserLinks.TreeGotoArgumentsParserLinks;

public class TreeGotoPathParserLink : CommandArgumentParserLinkBase<TreeGotoCommandBuilder>
{
    public override CommandArgumentParseResult Parse(StringsIterator iterator, TreeGotoCommandBuilder commandBuilder)
    {
        if (iterator.IsLast)
        {
            return new CommandArgumentParseResult.Failure(new ParsingError("Path not specified for command tree goto"));
        }

        commandBuilder.WithPath(iterator.MoveNext());

        if (iterator.IsLast)
        {
            return new CommandArgumentParseResult.Success(commandBuilder);
        }

        return CallNext(iterator, commandBuilder);
    }
}