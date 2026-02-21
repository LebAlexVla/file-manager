using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.ParsingAbstractions.Arguments;
using FileManager.Presentation.Parsing.ParsingAbstractions.SubCommands;

namespace FileManager.Presentation.Parsing.CommandsParsing.Tree.SubCommands;

public class TreeListParserLink : SubCommandParserLinkBase
{
    private readonly ICommandArgumentParserLink<TreeListCommandBuilder> _argumentsParserLink;

    public TreeListParserLink(ICommandArgumentParserLink<TreeListCommandBuilder> argumentsParserLink)
    {
        _argumentsParserLink = argumentsParserLink;
    }

    public override SubCommandParseResult Parse(StringsIterator iterator)
    {
        if (iterator.Current == "list")
        {
            var treelistCommandBuilder = new TreeListCommandBuilder();
            CommandArgumentParseResult result = _argumentsParserLink.Parse(iterator, treelistCommandBuilder);

            return result.ThenSubCommand();
        }

        return CallNext(iterator);
    }
}