using FileManager.Core.Commands.CommandBuilders;
using FileManager.Core.Errors;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;
using FileManager.Presentation.Parsing.CommandsParserLinks.FlagsValuesParsing.FileShowModeParsing;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.FileSubcommandsArgumentsParserLinks.FileShowArgumentsParserLinks;

public class FileShowModeFlagParserLink : CommandArgumentParserLinkBase<FileShowCommandBuilder>
{
    private readonly IFileShowModeParserLink _fileShowModeParserLink;

    public FileShowModeFlagParserLink(IFileShowModeParserLink fileShowModeParserLink)
    {
        _fileShowModeParserLink = fileShowModeParserLink;
    }

    public override CommandArgumentParseResult Parse(StringsStream stream, FileShowCommandBuilder commandBuilder)
    {
        if (stream.Current == "-m")
        {
            if (stream.IsLast)
            {
                return new CommandArgumentParseResult.Failure(new ParsingError("Lonely flag -m"));
            }

            FileShowModeParseResult result = _fileShowModeParserLink.Parse(stream.MoveNext());
            if (result is FileShowModeParseResult.Success(var fileShowMode))
            {
                return new CommandArgumentParseResult.Success(commandBuilder.WithFileWriter(fileShowMode));
            }

            if (result is FileShowModeParseResult.Failure(var error))
            {
                return new CommandArgumentParseResult.Failure(error);
            }
        }

        return CallNext(stream, commandBuilder);
    }
}