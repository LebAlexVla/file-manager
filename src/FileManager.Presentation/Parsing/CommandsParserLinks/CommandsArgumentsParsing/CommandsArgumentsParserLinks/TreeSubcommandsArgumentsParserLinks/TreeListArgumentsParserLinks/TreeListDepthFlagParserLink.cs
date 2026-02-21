using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.TreeSubcommandsArgumentsParserLinks.TreeListArgumentsParserLinks;

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