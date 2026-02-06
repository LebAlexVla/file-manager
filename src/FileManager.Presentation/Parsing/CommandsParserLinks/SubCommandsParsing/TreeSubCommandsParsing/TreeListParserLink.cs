using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;
using FileManager.Presentation.Parsing.CommandsParserLinks.SubCommandsParsing.SubCommandParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.SubCommandsParsing.TreeSubCommandsParsing;

public class TreeListParserLink : SubCommandParserLinkBase
{
    private readonly ICommandArgumentParserLink<TreeListCommandBuilder> _argumentsParserLink;

    public TreeListParserLink(ICommandArgumentParserLink<TreeListCommandBuilder> argumentsParserLink)
    {
        _argumentsParserLink = argumentsParserLink;
    }

    public override SubCommandParseResult Parse(StringsStream stream)
    {
        if (stream.Current == "list")
        {
            var treelistCommandBuilder = new TreeListCommandBuilder();
            CommandArgumentParseResult result = _argumentsParserLink.Parse(stream, treelistCommandBuilder);

            return result.ThenSubCommand();
        }

        return CallNext(stream);
    }
}