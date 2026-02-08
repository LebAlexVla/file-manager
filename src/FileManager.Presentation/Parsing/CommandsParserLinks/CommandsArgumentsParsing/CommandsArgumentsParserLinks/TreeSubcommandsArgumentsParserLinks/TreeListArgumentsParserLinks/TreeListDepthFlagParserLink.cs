using FileManager.Core.Commands.CommandBuilders;
using FileManager.Core.Errors;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.TreeSubcommandsArgumentsParserLinks.TreeListArgumentsParserLinks;

public class TreeListDepthFlagParserLink : CommandArgumentParserLinkBase<TreeListCommandBuilder>
{
    public override CommandArgumentParseResult Parse(StringsStream stream, TreeListCommandBuilder commandBuilder)
    {
        if (stream.IsLast)
        {
            return new CommandArgumentParseResult.Success(commandBuilder);
        }

        if (stream.MoveNext() == "-d")
        {
            if (stream.IsLast)
            {
                return new CommandArgumentParseResult.Failure(new ParsingError("Lonely flag -d"));
            }

            if (!int.TryParse(stream.MoveNext(), out int depth))
            {
                return new CommandArgumentParseResult.Failure(new ParsingError("Wrong depth"));
            }

            if (stream.IsLast)
            {
                return new CommandArgumentParseResult.Success(commandBuilder.WithDepth(depth));
            }
        }

        return CallNext(stream, commandBuilder);
    }
}