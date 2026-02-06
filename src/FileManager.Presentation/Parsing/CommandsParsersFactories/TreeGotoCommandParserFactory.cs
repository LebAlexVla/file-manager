using FileManager.Presentation.Parsing.CommandsParserLinks;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.TreeSubcommandsArgumentsParserLinks.TreeGotoArgumentsParserLinks;
using FileManager.Presentation.Parsing.CommandsParserLinks.SubCommandsParsing.TreeSubCommandsParsing;

namespace FileManager.Presentation.Parsing.CommandsParsersFactories;

public class TreeGotoCommandParserFactory : ICommandParserFactory
{
    public ICommandParserLink Create()
    {
        return new TreeCommandsParserLink(
            new TreeGotoParserLink(new TreeGotoPathParserLink()));
    }
}