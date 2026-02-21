using FileManager.Presentation.Parsing.CommandsParsing.File;
using FileManager.Presentation.Parsing.CommandsParsing.File.Arguments.FileCopy;
using FileManager.Presentation.Parsing.CommandsParsing.File.Arguments.FileDelete;
using FileManager.Presentation.Parsing.CommandsParsing.File.Arguments.FileMove;
using FileManager.Presentation.Parsing.CommandsParsing.File.Arguments.FileRename;
using FileManager.Presentation.Parsing.CommandsParsing.File.Arguments.FileShow;
using FileManager.Presentation.Parsing.CommandsParsing.File.FlagsValues.FileShowMode.ModeParsers;
using FileManager.Presentation.Parsing.CommandsParsing.File.SubCommands;
using FileManager.Presentation.Parsing.ParsingAbstractions.Commands;

namespace FileManager.Presentation.Parsing.CommandsParsersFactories;

public class FileCommandParserFactory : ICommandParserFactory
{
    public ICommandParserLink Create()
    {
        var fileShowParser = new FileShowParserLink(
            new FileShowPathParserLink().AddNext(
                new FileShowModeFlagParserLink(
                    new ConsoleFileShowModeParser())));

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