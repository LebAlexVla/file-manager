using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.ParsingAbstractions.Arguments;

namespace FileManager.Presentation.Parsing.CommandsParsing.Tree.Arguments.TreeList;

public class TreeListDepthFlagParserLink : CommandArgumentParserLinkBase<TreeListCommandBuilder>
{
    public override CommandArgumentParseResult Parse(StringsIterator iterator, TreeListCommandBuilder commandBuilder)
    {
        if (iterator.IsLast)
        {
            return new CommandArgumentParseResult.Success(commandBuilder);
        }

        if (iterator.MoveNext() == "-d")
        {
            if (iterator.IsLast)
            {
                return new CommandArgumentParseResult.Failure(new ParsingError("Lonely flag -d"));
            }

            if (!int.TryParse(iterator.MoveNext(), out int depth))
            {
                return new CommandArgumentParseResult.Failure(new ParsingError("Wrong depth"));
            }

            if (iterator.IsLast)
            {
                return new CommandArgumentParseResult.Success(commandBuilder.WithDepth(depth));
            }
        }

        return CallNext(iterator, commandBuilder);
    }
}