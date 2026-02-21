using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.ParsingAbstractions.Arguments;
using FileManager.Presentation.Parsing.ParsingAbstractions.SubCommands;

namespace FileManager.Presentation.Parsing.CommandsParsing.Tree.SubCommands;

public class TreeGotoParserLink : SubCommandParserLinkBase
{
    private readonly ICommandArgumentParserLink<TreeGotoCommandBuilder> _argumentsParserLink;

    public TreeGotoParserLink(ICommandArgumentParserLink<TreeGotoCommandBuilder> argumentsParserLink)
    {
        _argumentsParserLink = argumentsParserLink;
    }

    public override SubCommandParseResult Parse(StringsIterator iterator)
    {
        if (iterator.MoveNext() == "goto")
        {
            var treeGotoCommandBuilder = new TreeGotoCommandBuilder();
            CommandArgumentParseResult result = _argumentsParserLink.Parse(iterator, treeGotoCommandBuilder);

            return result.ThenSubCommand();
        }

        return CallNext(iterator);
    }
}