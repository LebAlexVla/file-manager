using FileManager.Presentation.Parsing.CommandsParserLinks;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.TreeSubcommandsArgumentsParserLinks.TreeListArgumentsParserLinks;
using FileManager.Presentation.Parsing.CommandsParserLinks.SubCommandsParsing.TreeSubCommandsParsing;

namespace FileManager.Presentation.Parsing.CommandsParsersFactories;

public class TreeListCommandParserFactory : ICommandParserFactory
{
    public ICommandParserLink Create()
    {
        return new TreeCommandsParserLink(
            new TreeListParserLink(new TreeListDepthFlagParserLink()));
    }
}