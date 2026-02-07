using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.CommandsParserLinks;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.TreeSubcommandsArgumentsParserLinks.FileShowArgumentsParserLinks;
using FileManager.Presentation.Parsing.CommandsParserLinks.FlagsValuesParsing.FileShowModeParsing.FileShowModeParserLinks;
using FileManager.Presentation.Parsing.CommandsParserLinks.SubCommandsParsing.FileSubCommandsParsing;

namespace FileManager.Presentation.Parsing.CommandsParsersFactories;

public class FileShowCommandParserFactory : ICommandParserFactory
{
    public ICommandParserLink Create()
    {
        ICommandArgumentParserLink<FileShowCommandBuilder> fileShowArgumentsChain =
            new FileShowPathParserLink().AddNext(
                new FileShowModeFlagParserLink(
                    new ConsoleFileShowModeParserLink()));

        return new FileCommandsParserLink(new FileShowParserLink(fileShowArgumentsChain));
    }
}