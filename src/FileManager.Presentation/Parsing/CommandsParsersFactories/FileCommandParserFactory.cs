using FileManager.Presentation.Parsing.CommandsParserLinks;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.FileSubcommandsArgumentsParserLinks.FileCopyArgumentsParserLinks;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.FileSubcommandsArgumentsParserLinks.FileDeleteArgumentsParserLinks;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.FileSubcommandsArgumentsParserLinks.FileMoveArgumentsParserLinks;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.FileSubcommandsArgumentsParserLinks.FileRenameArgumentsParserLinks;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.FileSubcommandsArgumentsParserLinks.FileShowArgumentsParserLinks;
using FileManager.Presentation.Parsing.CommandsParserLinks.FlagsValuesParsing.FileShowModeParsing.FileShowModeParserLinks;
using FileManager.Presentation.Parsing.CommandsParserLinks.SubCommandsParsing.FileSubCommandsParsing;

namespace FileManager.Presentation.Parsing.CommandsParsersFactories;

public class FileCommandParserFactory : ICommandParserFactory
{
    public ICommandParserLink Create()
    {
        var fileShowParser = new FileShowParserLink(
            new FileShowPathParserLink().AddNext(
                new FileShowModeFlagParserLink(
                    new ConsoleFileShowModeParserLink())));

        var fileMoveParser = new FileMoveParserLink(
            new FileMoveSourcePathParserLink().AddNext(
                new FileMoveDestinationPathParserLink()));

        var fileCopyParser = new FileCopyParserLink(
            new FileCopySourcePathParserLink().AddNext(
                new FileCopyDestinationPathParserLink()));

        var fileDeleteParser = new FileDeleteParserLink(new FileDeletePathParserLink());

        var fileRenameParser = new FileRenameParserLink(
            new FileRenamePathParserLink().AddNext(
                new FileRenameNameParserLink()));

        fileShowParser
            .AddNext(fileMoveParser)
            .AddNext(fileCopyParser)
            .AddNext(fileDeleteParser)
            .AddNext(fileRenameParser);

        return new FileCommandsParserLink(fileShowParser);
    }
}