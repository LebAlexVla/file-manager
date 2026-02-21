using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.ParsingAbstractions.Arguments;

namespace FileManager.Presentation.Parsing.CommandsParsing.Tree.Arguments.TreeGoto;

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