using FileManager.Core.Commands.CommandBuilders;
using FileManager.Core.Errors;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.TreeSubcommandsArgumentsParserLinks.TreeListArgumentsParserLinks;

public class TreeListDepthFlagParserLink : CommandArgumentParserLinkBase<TreeListCommandBuilder>
{
    public override CommandArgumentParseResult Parse(StringsStream stream, TreeListCommandBuilder commandBuilder)
    {
        if (stream.Current == "-d")
        {
            if (stream.IsLast)
            {
                return new CommandArgumentParseResult.Failure(new ParsingError("Lonely flag -d"));
            }

            return new CommandArgumentParseResult.Success(commandBuilder.WithDepth(stream.MoveNext()));
        }

        return CallNext(stream, commandBuilder);
    }
}