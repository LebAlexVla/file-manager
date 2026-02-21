using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;
using FileManager.Presentation.Parsing.CommandsParserLinks.FlagsValuesParsing.FileShowModeParsing;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.FileSubcommandsArgumentsParserLinks.FileShowArgumentsParserLinks;

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