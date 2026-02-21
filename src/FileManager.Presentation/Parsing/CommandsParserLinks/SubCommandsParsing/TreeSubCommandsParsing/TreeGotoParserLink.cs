using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;
using FileManager.Presentation.Parsing.CommandsParserLinks.SubCommandsParsing.SubCommandParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.SubCommandsParsing.TreeSubCommandsParsing;

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