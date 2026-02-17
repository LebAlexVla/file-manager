using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.FileSubcommandsArgumentsParserLinks.FileMoveArgumentsParserLinks;

public class FileMoveSourcePathParserLink : CommandArgumentParserLinkBase<FileMoveCommandBuilder>
{
    public override CommandArgumentParseResult Parse(StringsStream stream, FileMoveCommandBuilder commandBuilder)
    {
        if (stream.IsLast)
        {
            return new CommandArgumentParseResult.Failure(new ParsingError("No file move source path"));
        }

        commandBuilder.WithSourcePath(stream.MoveNext());

        return CallNext(stream, commandBuilder);
    }
}