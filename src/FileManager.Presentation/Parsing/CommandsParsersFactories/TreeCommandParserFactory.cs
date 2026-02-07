using FileManager.Presentation.Parsing.CommandsParserLinks;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.TreeSubcommandsArgumentsParserLinks.TreeGotoArgumentsParserLinks;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.TreeSubcommandsArgumentsParserLinks.TreeListArgumentsParserLinks;
using FileManager.Presentation.Parsing.CommandsParserLinks.SubCommandsParsing.TreeSubCommandsParsing;

namespace FileManager.Presentation.Parsing.CommandsParsersFactories;

public class TreeCommandParserFactory : ICommandParserFactory
{
    public ICommandParserLink Create()
    {
        var treeGotoParser = new TreeGotoParserLink(new TreeGotoPathParserLink());
        var treeListParser = new TreeListParserLink(new TreeListDepthFlagParserLink());

        treeGotoParser.AddNext(treeListParser);

        return new TreeCommandsParserLink(treeGotoParser);
    }
}