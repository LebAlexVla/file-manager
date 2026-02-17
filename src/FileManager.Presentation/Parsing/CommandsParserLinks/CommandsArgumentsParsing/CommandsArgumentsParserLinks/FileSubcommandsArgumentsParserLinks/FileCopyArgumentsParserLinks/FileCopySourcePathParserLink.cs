using FileManager.Core.Commands.CommandBuilders;
using FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandArgumentParseResults;

namespace FileManager.Presentation.Parsing.CommandsParserLinks.CommandsArgumentsParsing.CommandsArgumentsParserLinks.FileSubcommandsArgumentsParserLinks.FileCopyArgumentsParserLinks;

public class FileCopySourcePathParserLink : CommandArgumentParserLinkBase<FileCopyCommandBuilder>
{
    public override CommandArgumentParseResult Parse(StringsStream stream, FileCopyCommandBuilder commandBuilder)
    {
        if (stream.IsLast)
        {
            return new CommandArgumentParseResult.Failure(new ParsingError("No file copy source path"));
        }

        commandBuilder.WithSourcePath(stream.MoveNext());

        return CallNext(stream, commandBuilder);
    }
}