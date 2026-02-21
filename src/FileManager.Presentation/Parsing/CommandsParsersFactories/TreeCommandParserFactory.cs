using FileManager.Presentation.Parsing.CommandsParsing.Tree;
using FileManager.Presentation.Parsing.CommandsParsing.Tree.Arguments.TreeGoto;
using FileManager.Presentation.Parsing.CommandsParsing.Tree.Arguments.TreeList;
using FileManager.Presentation.Parsing.CommandsParsing.Tree.SubCommands;
using FileManager.Presentation.Parsing.ParsingAbstractions.Commands;

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