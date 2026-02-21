using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.CommandsParsing.File.FlagsValues.FileShowMode;
using FileManager.Presentation.Parsing.ParsingAbstractions.Arguments;

namespace FileManager.Presentation.Parsing.CommandsParsing.File.Arguments.FileShow;

public class FileShowModeFlagParserLink : CommandArgumentParserLinkBase<FileShowCommandBuilder>
{
    private readonly IFileShowModeParser _fileShowModeParser;

    public FileShowModeFlagParserLink(IFileShowModeParser fileShowModeParser)
    {
        _fileShowModeParser = fileShowModeParser;
    }

    public override CommandArgumentParseResult Parse(StringsIterator iterator, FileShowCommandBuilder commandBuilder)
    {
        if (iterator.Current == "-m")
        {
            if (iterator.IsLast)
            {
                return new CommandArgumentParseResult.Failure(new ParsingError("Lonely flag -m"));
            }

            FileShowModeParseResult result = _fileShowModeParser.Parse(iterator.MoveNext());
            if (result is FileShowModeParseResult.Success(var fileShowMode))
            {
                commandBuilder.WithFileWriter(fileShowMode);
            }

            if (iterator.IsLast)
            {
                return new CommandArgumentParseResult.Success(commandBuilder);
            }

            if (result is FileShowModeParseResult.Failure(var error))
            {
                return new CommandArgumentParseResult.Failure(error);
            }
        }

        return CallNext(iterator, commandBuilder);
    }
}